using Ample.Core.GuardClauses;
using IPLocateNet.App.Repositories.Abstractions;
using IPLocateNet.Domain.Specifications.Abstractions;
using IPLocateNet.Inf.Data.Specifications;
using Microsoft.EntityFrameworkCore;

namespace IPLocateNet.Inf.Data.Repositories;

public abstract class ReadRepositoryBase<T>(DbContext db)
    : IReadRepository<T> where T : class
{
    private readonly DbContext _db = Guard.Against.Null(db);
    private readonly SpecificationEvaluator _evaluator = SpecificationEvaluator.Default;

    protected virtual IQueryable<T> ReadQuery => _db.Set<T>().AsNoTrackingWithIdentityResolution().AsQueryable();

    public virtual async Task<IReadOnlyList<T>> ListAsync(ISpecification<T>? specification = null,
                                                          CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification);
        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> GetAsync(ISpecification<T>? specification, CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification);
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<int> CountAsync(ISpecification<T>? specification = null, CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification);
        return await query.CountAsync(cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(ISpecification<T>? specification = null, CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification);
        return await query.AnyAsync(cancellationToken);
    }

    protected virtual IQueryable<T> ApplySpecification(ISpecification<T>? specification)
    {
        return specification is null ? ReadQuery : _evaluator.GetQuery(ReadQuery, specification);
    }
}
