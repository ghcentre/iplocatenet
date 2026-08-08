namespace IPLocateNet.App.Repositories.Abstractions;

public interface IInsertRepository<T> : IHasUnitOfWorkRepository where T : class
{
    Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> InsertRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}
