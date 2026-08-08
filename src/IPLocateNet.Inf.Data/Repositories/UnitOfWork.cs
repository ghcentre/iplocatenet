using Ample.Core.GuardClauses;
using IPLocateNet.App.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace IPLocateNet.Inf.Data.Repositories;

public class UnitOfWork(DbContext db, Func<IDbContextTransaction, IUnitOfWorkTransaction> transactionFactory) : IUnitOfWork
{
    private readonly DbContext _db = Guard.Against.Null(db);
    private readonly Func<IDbContextTransaction, IUnitOfWorkTransaction> _transactionFactory = Guard.Against.Null(transactionFactory);

    public bool SupportsTransactions => true;

    public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        var dbTransaction = await _db.Database.BeginTransactionAsync(cancellationToken);
        return _transactionFactory(dbTransaction);
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }
}
