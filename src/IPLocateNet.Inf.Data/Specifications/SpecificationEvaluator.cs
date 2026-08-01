using Ample.Core.GuardClauses;
using IPLocateNet.App.Specifications;
using IPLocateNet.App.Specifications.Abstractions;
using IPLocateNet.Domain.Specifications.Abstractions;

namespace IPLocateNet.Inf.Data.Specifications;

public class SpecificationEvaluator : ISpecificationEvaluator
{
    private readonly List<ISpecificationEvaluator> _evaluators =
        [
            SpecificationWhereEvaluator.Default,
            SpecificationOrderEvaluator.Default,
            SpecificationIncludeEvaluator.Default
        ];

    public SpecificationEvaluator()
    {
    }

    public static SpecificationEvaluator Default { get; } = new SpecificationEvaluator();

    public virtual IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification)
    {
        Guard.Against.Null(query);
        Guard.Against.Null(specification);

        foreach (var evaluator in _evaluators)
        {
            query = evaluator.GetQuery(query, specification);
        }

        return query;
    }
}
