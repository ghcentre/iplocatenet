using IPLocateNet.App.Specifications.Abstractions;
using IPLocateNet.Domain.Entities;
using IPLocateNet.Inf.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IPLocateNet.Inf.Data.LocalRepositories;

public class IPv4RangeRepository(AppDbContext db) : ReadRepositoryBase<IPv4Range>(db)
{
}
