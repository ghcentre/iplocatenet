using System;
using System.Collections.Generic;
using System.Text;

namespace IPLocateNet.App.Repositories.Abstractions;

public interface IUnitOfWork
{
    bool SupportsTransactions { get; }

    Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    Task SaveAsync(CancellationToken cancellationToken = default);
}
