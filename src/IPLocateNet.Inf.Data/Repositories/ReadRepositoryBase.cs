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

    protected virtual IQueryable<T> Query => _db.Set<T>().AsNoTrackingWithIdentityResolution().AsQueryable();

    public virtual async Task<IReadOnlyList<T>> ListAsync(ISpecification<T>? specification = null, CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification);
        return await query.ToListAsync(cancellationToken);
    }

    protected virtual IQueryable<T> ApplySpecification(ISpecification<T>? specification)
    {
        return specification is null ? Query : _evaluator.GetQuery(Query, specification);
    }
}
