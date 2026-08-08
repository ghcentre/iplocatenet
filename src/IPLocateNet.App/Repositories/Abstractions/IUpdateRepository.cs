namespace IPLocateNet.App.Repositories.Abstractions;

public interface IUpdateRepository<T> : IHasUnitOfWorkRepository where T : class
{
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
}
