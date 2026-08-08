using Ample.Core.GuardClauses;
using IPLocateNet.App.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

namespace IPLocateNet.Inf.Data.Repositories;

public class UnitOfWorkTransaction(IDbContextTransaction contextTransaction) : IUnitOfWorkTransaction
{
    private readonly IDbContextTransaction _contextTransaction = Guard.Against.Null(contextTransaction);

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _contextTransaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await _contextTransaction.RollbackAsync(cancellationToken);
    }
}
