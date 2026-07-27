using Ample.Core.GuardClauses;
using IPLocateNet.Domain.Specifications.Abstractions;

namespace IPLocateNet.Domain.Specifications;

public abstract class Specification<T> : ISpecification<T>
{
    private readonly List<SpecificationWhereExpression<T>> _whereExpressions;
    private readonly List<SpecificationOrderExpression<T>> _orderExpressions;
    private readonly List<SpecificationIncludeExpression<T>> _includeExpressions;

    protected virtual SpecificationBuilder<T> Query { get; }

    public Specification() : this([], [], []) { }

    public Specification(IEnumerable<SpecificationWhereExpression<T>> whereExpressions,
                         IEnumerable<SpecificationOrderExpression<T>> orderExpressions,
                         IEnumerable<SpecificationIncludeExpression<T>> includeExpressions)
    {
        _whereExpressions = [.. Guard.Against.Null(whereExpressions)];
        _orderExpressions = [.. Guard.Against.Null(orderExpressions)];
        _includeExpressions = [.. Guard.Against.Null(includeExpressions)];
        Query = new SpecificationBuilder<T>(this);
    }

    public virtual IEnumerable<SpecificationWhereExpression<T>> WhereExpressions => _whereExpressions;

    public virtual IEnumerable<SpecificationOrderExpression<T>> OrderExpressions => _orderExpressions;

    public virtual IEnumerable<SpecificationIncludeExpression<T>> IncludeExpressions => _includeExpressions;

    internal void AddWhereExpression(SpecificationWhereExpression<T> expression)
    {
        Guard.Against.Null(expression);
        _whereExpressions.Add(expression);
    }

    internal void AddOrderExpression(SpecificationOrderExpression<T> expression)
    {
        Guard.Against.Null(expression);
        _orderExpressions.Add(expression);
    }

    internal void AddIncludeExpression(SpecificationIncludeExpression<T> expression)
    {
        Guard.Against.Null(expression);
        _includeExpressions.Add(expression);
    }

    public bool IsSatisfiedBy(T entity)
    {
        foreach (var expression in WhereExpressions)
        {
            var predicate = expression.Func;
            if (!predicate(entity))
            {
                return false;
            }
        }

        return true;
    }
}
