namespace IPLocateNet.App.Repositories.Abstractions;

public interface IUnitOfWorkTransaction
{
    Task CommitAsync(CancellationToken cancellationToken = default);

    Task RollbackAsync(CancellationToken cancellationToken = default);
}