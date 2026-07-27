using Ample.Core.GuardClauses;

namespace IPLocateNet.Domain.Specifications;

public class SpecificationBuilder<T>(Specification<T> specification)
{
    public Specification<T> Specification { get; } = Guard.Against.Null(specification);
}
