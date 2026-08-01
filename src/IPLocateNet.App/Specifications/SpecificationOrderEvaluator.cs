using Ample.Core.GuardClauses;
using IPLocateNet.App.Specifications.Abstractions;
using IPLocateNet.Domain.Specifications.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPLocateNet.App.Specifications;

public class SpecificationOrderEvaluator : ISpecificationEvaluator
{
    private SpecificationOrderEvaluator() { }
    
    public static SpecificationOrderEvaluator Default { get; } = new SpecificationOrderEvaluator();

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> specification)
    {
        Guard.Against.Null(query);
        Guard.Against.Null(specification);
        
        IOrderedQueryable<T>? ordered = null;

        foreach(var orderExpression in specification.OrderExpressions)
        {
            if (orderExpression.OrderType == SpecificationOrderType.Ascending)
            {
                ordered = ordered == null
                    ? query.OrderBy(orderExpression.KeySelector)
                    : ordered.ThenBy(orderExpression.KeySelector);

                continue;
            }

            if (orderExpression.OrderType == SpecificationOrderType.Descending)
            {
                ordered = ordered == null
                    ? query.OrderByDescending(orderExpression.KeySelector)
                    : ordered.ThenByDescending(orderExpression.KeySelector);

                continue;
            }
        }

        return ordered ?? query;
    }
}
