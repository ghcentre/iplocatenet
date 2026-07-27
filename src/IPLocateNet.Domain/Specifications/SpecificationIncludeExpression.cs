using Ample.Core.GuardClauses;
using System.Linq.Expressions;

namespace IPLocateNet.Domain.Specifications;

public class SpecificationIncludeExpression<T>
{
    internal SpecificationIncludeExpression(LambdaExpression expression, Type propertyType)
    {
        Expression = Guard.Against.Null(expression);
        PropertyType = Guard.Against.Null(propertyType);
    }

    public LambdaExpression Expression { get; }

    public Type PropertyType { get; }
}

internal class SpecificationIncludeExpressionTyped<T, TProperty> : SpecificationIncludeExpression<T>
{
    public SpecificationIncludeExpressionTyped(Expression<Func<T, TProperty>> expression)
        : base(expression, typeof(TProperty))
    {
    }
}

