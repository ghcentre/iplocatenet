namespace IPLocateNet.Domain.Specifications.Abstractions;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);

    IEnumerable<SpecificationWhereExpression<T>> WhereExpressions { get; }

    IEnumerable<SpecificationOrderExpression<T>> OrderExpressions { get; }

    IEnumerable<SpecificationIncludeExpression<T>> IncludeExpressions { get; }
}
