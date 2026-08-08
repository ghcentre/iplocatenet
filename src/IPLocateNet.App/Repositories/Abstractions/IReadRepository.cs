using IPLocateNet.Domain.Specifications.Abstractions;

namespace IPLocateNet.App.Repositories.Abstractions;

public interface IReadRepository<T> where T : class
{
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T>? specification = default, CancellationToken cancellationToken = default);

    Task<T?> GetAsync(ISpecification<T>? specification, CancellationToken cancellationToken = default);

    Task<int> CountAsync(ISpecification<T>? specification = default, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(ISpecification<T>? specification = default, CancellationToken cancellationToken = default);
}
