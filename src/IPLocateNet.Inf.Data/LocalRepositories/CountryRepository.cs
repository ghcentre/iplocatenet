using IPLocateNet.App.Repositories.Abstractions;
using IPLocateNet.Domain.Entities;
using IPLocateNet.Inf.Data.Repositories;

namespace IPLocateNet.Inf.Data.LocalRepositories;

public class CountryRepository(AppDbContext db, IUnitOfWork uow) : RepositoryBase<Country>(db, uow)
{
}
