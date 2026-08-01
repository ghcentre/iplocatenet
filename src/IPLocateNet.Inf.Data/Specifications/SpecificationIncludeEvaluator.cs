using Ample.Core.GuardClauses;
using IPLocateNet.App.Specifications.Abstractions;
using IPLocateNet.Domain.Specifications;
using IPLocateNet.Domain.Specifications.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace IPLocateNet.Inf.Data.Specifications;

public class SpecificationIncludeEvaluator : ISpecificationEvaluator
{
    private SpecificationIncludeEvaluator() { }

    public static SpecificationIncludeEvaluator Default { get; } = new SpecificationIncludeEvaluator();

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification)
    {
        Guard.Against.Null(query);
        Guard.Against.Null(specification);

        foreach (var expression in specification.IncludeExpressions)
        {
            query = Include(query, expression);
        }

        return query;
    }

    private static IQueryable<T> Include<T>(IQueryable<T> query, SpecificationIncludeExpression<T> expression) 
    {
        var includeMethod = _includeMethodInfo.MakeGenericMethod(typeof(T), expression.PropertyType);
        if (includeMethod.Invoke(null, [query, expression.Expression]) is not IQueryable<T> result)
        {
            throw new InvalidOperationException("Include failed.");
        }
        return result;
    }

    private static readonly MethodInfo _includeMethodInfo =
        typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.Include))
            .Single(mi => mi.GetGenericArguments().Length == 2 &&
                          mi.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IQueryable<>) &&
                          mi.GetParameters()[1].ParameterType.GetGenericTypeDefinition() == typeof(Expression<>));
}
