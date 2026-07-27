using IPLocateNet.Domain.Specifications.Abstractions;

namespace IPLocateNet.App.Specifications.Abstractions;

public interface ISpecificationEvaluator
{
    IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification) where T : class;
}
