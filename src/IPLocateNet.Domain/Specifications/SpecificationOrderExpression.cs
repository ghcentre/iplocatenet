using Ample.Core.GuardClauses;
using IPLocateNet.Domain.Specifications.Abstractions;
using System.Linq.Expressions;

namespace IPLocateNet.Domain.Specifications;

public sealed class SpecificationOrderExpression<T>(Expression<Func<T, object?>> keySelector, SpecificationOrderType orderType)
{
    public Expression<Func<T, object?>> KeySelector { get; } = Guard.Against.Null(keySelector);
    
    public SpecificationOrderType OrderType { get; } = orderType;
}
