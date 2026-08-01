using Ample.Core.GuardClauses;
using IPLocateNet.App.Specifications.Abstractions;
using IPLocateNet.Domain.Specifications.Abstractions;

namespace IPLocateNet.App.Specifications;

public class SpecificationWhereEvaluator : ISpecificationEvaluator
{
    private SpecificationWhereEvaluator() { }

    public static SpecificationWhereEvaluator Default { get; } = new SpecificationWhereEvaluator();

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification)
    {
        Guard.Against.Null(query);
        Guard.Against.Null(specification);

        foreach (var expression in specification.WhereExpressions)
        {
            query = query.Where(expression.Predicate);
        }

        return query;
    }
}
