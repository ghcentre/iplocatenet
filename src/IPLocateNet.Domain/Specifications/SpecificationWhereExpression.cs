using Ample.Core.GuardClauses;
using System.Linq.Expressions;

namespace IPLocateNet.Domain.Specifications;

public sealed class SpecificationWhereExpression<T>(Expression<Func<T, bool>> predicate)
{
    private readonly Lazy<Func<T, bool>> _funcLazy = new(() => predicate.Compile());

    public Expression<Func<T, bool>> Predicate { get; } = Guard.Against.Null(predicate);

    public Func<T, bool> Func => _funcLazy.Value;
}
