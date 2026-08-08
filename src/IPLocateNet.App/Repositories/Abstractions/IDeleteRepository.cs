using System;
using System.Collections.Generic;
using System.Text;

namespace IPLocateNet.App.Repositories.Abstractions;

public interface IDeleteRepository<T> : IHasUnitOfWorkRepository where T : class
{
    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}
