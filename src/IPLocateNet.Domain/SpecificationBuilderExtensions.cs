using IPLocateNet.Domain.Specifications;
using IPLocateNet.Domain.Specifications.Abstractions;
using System.Linq.Expressions;

namespace IPLocateNet.Domain;

public static class SpecificationBuilderExtensions
{
    extension<T>(SpecificationBuilder<T> builder)
    {
        public SpecificationBuilder<T> Where(Expression<Func<T, bool>> predicate)
        {
            var whereExpression = new SpecificationWhereExpression<T>(predicate);
            builder.Specification.AddWhereExpression(whereExpression);
            return builder;
        }

        public SpecificationBuilder<T> OrderBy(Expression<Func<T, object?>> expression)
        {
            var orderExpression = new SpecificationOrderExpression<T>(expression, SpecificationOrderType.Ascending);
            builder.Specification.AddOrderExpression(orderExpression);
            return builder;
        }

        public SpecificationBuilder<T> OrderByDescending(Expression<Func<T, object?>> expression)
        {
            var orderExpression = new SpecificationOrderExpression<T>(expression, SpecificationOrderType.Descending);
            builder.Specification.AddOrderExpression(orderExpression);
            return builder;
        }

        public SpecificationBuilder<T> Include<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var includeExpression = new SpecificationIncludeExpressionTyped<T, TProperty>(expression);
            builder.Specification.AddIncludeExpression(includeExpression);
            return builder;
        }
    }
}
