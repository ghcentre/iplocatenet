using Ample.Core.GuardClauses;
using IPLocateNet.App.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;

namespace IPLocateNet.Inf.Data.Repositories;

public abstract class RepositoryBase<T>(DbContext db, IUnitOfWork uow)
    : ReadRepositoryBase<T>(db),
      IInsertRepository<T>,
      IUpdateRepository<T>,
      IDeleteRepository<T>
      where T : class
{
    private readonly IUnitOfWork _uow = Guard.Against.Null(uow);
    private readonly DbContext _db = Guard.Against.Null(db);

    protected virtual DbSet<T> Set { get; set; } = Guard.Against.Null(db).Set<T>();

    public IUnitOfWork UnitOfWork => _uow;

    public virtual async Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity);

        GraphResolver.Resolve(_db, entity);

        await Set.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entities);

        foreach (var entity in entities)
        {
            GraphResolver.Resolve(_db, entity);
        }

        await Set.AddRangeAsync(entities, cancellationToken);
        return entities;
    }

    public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity);

        await ReplaceAttachedEntityAsync(entity, EntityState.Modified, cancellationToken);
        GraphResolver.Resolve(_db, entity);
        Set.Update(entity);

        return entity;
    }

    public virtual async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entity);
        ReplaceLocalAttached(entity);
        Set.Remove(entity);
        return entity;
    }

    public virtual async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        Guard.Against.Null(entities);

        foreach (var entity in entities)
        {
            ReplaceLocalAttached(entity);
        }

        Set.RemoveRange(entities);
        return entities;
    }

    private void ReplaceLocalAttached(T entity)
    {
        var localEntity = FindLocal(entity);
        if (localEntity != null)
        {
            var localEntry = _db.Entry(localEntity);
            localEntry.State = EntityState.Detached;
        }
        var newEntry = _db.Entry(entity);
        newEntry.State = EntityState.Unchanged;
    }

    /// <summary>
    /// Find a entity with key values stored in <paramref name="entity"/> without quering the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>The entity in local cache or <see langword="null"/> if none found</returns>
    private T? FindLocal(T entity)
    {
        var entry = _db.Entry(entity);
        var key = entry.Metadata.FindPrimaryKey();
        var properties = key?.Properties;

        var values = properties?.Select(x => entry.Property(x.Name).CurrentValue).ToArray();
        if (values?.All(x => x != null) != true)
        {
            return null;
        }

        bool predicate(T x)
        {
            for (int i = 0; i < values.Length; i++)
            {
                string name = properties![i].Name;
                var currentEntry = _db.Entry(x);
                var currentValue = currentEntry.Property(name).CurrentValue;
                if (!Equals(values[i], currentValue))
                {
                    return false;
                }
            }
            return true;
        }

        var localEntity = _db.Set<T>().Local.FirstOrDefault(predicate);
        return localEntity;
    }

    private void AttachForDeletion(T entity)
    {
        var entry = _db.Entry(entity);
        var key = entry.Metadata.FindPrimaryKey();
        var properties = key?.Properties;
        var keyValues = properties?.Select(x => entry.Property(x.Name).CurrentValue).ToArray();
        if (keyValues?.All(x => x != null) == true)
        {
            bool predicate(T x)
            {
                for (int i = 0; i < keyValues.Length; i++)
                {
                    var propertyName = properties?[i].Name;
                    var currentKeyValue = entry.Property(propertyName!).CurrentValue;
                    var entityKeyValue = keyValues[i];
                    if (!Equals(currentKeyValue, entityKeyValue))
                    {
                        return false;
                    }
                }
                return true;
            }

            var local = _db.Set<T>().Local.FirstOrDefault(predicate);

        }
    }

    protected virtual async Task ReplaceAttachedEntityAsync(T entity, EntityState newState, CancellationToken cancellationToken)
    {
        var entry = _db.Entry(entity);
        if (entry?.State != EntityState.Detached)
        {
            return;
        }

        var key = entry.Metadata.FindPrimaryKey();
        var keyValues = key?.Properties.Select(x => entry.Property(x.Name).CurrentValue).ToArray();

        if (keyValues?.All(x => x != null) == true)
        {
            var existingEntity = await _db.FindAsync(typeof(T), keyValues, cancellationToken);
            if (existingEntity != null)
            {
                var existingEntry = _db.Entry(existingEntity);
                existingEntry.State = EntityState.Detached;
                entry.State = newState;
            }
        }
    }

    private static class GraphResolver
    {
        public static void Resolve(DbContext db, object root)
        {
            var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
            ResolveEntity(db, root, visited, replaceRoot: false);
        }

        private static object ResolveEntity(DbContext db,
                                            object entity,
                                            HashSet<object> visited,
                                            bool replaceRoot)
        {
            if (!visited.Add(entity))
            {
                return entity;
            }

            var entry = db.Entry(entity);

            if (replaceRoot && entry.State == EntityState.Detached && entry.Metadata.FindPrimaryKey() is IKey key)
            {
                var keyValues = key.Properties.Select(x => entry.Property(x.Name).CurrentValue).ToArray();

                if (keyValues.All(x => x != null))
                {
                    var entityType = entity.GetType();
                    if (db.Find(entityType, keyValues) is { } tracked)
                    {
                        var trackedEntry = db.Entry(tracked);
                        entity = tracked;
                        entry = db.Entry(entity);
                    }
                }
            }

            var navigations = entry.Metadata.GetNavigations();
            foreach (var navigation in navigations)
            {
                var navEntry = entry.Navigation(navigation.Name);

                if (navigation.IsCollection)
                {
                    if (navEntry.CurrentValue is not IList list)
                    {
                        continue;
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is not { } child)
                        {
                            continue;
                        }

                        var resolved = ResolveEntity(db, child, visited, true);
                        if (!ReferenceEquals(child, resolved))
                        {
                            list[i] = resolved;
                        }
                    }

                    continue;
                }
                else
                {
                    if (navEntry.CurrentValue is not { } child)
                    {
                        continue;
                    }

                    var resolved = ResolveEntity(db, child, visited, true);
                    if (!ReferenceEquals(child, resolved))
                    {
                        navEntry.CurrentValue = resolved;
                    }
                }
            }

            return entity;
        }
    }
}
