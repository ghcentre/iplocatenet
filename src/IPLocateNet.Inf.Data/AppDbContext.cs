using IPLocateNet.Domain;
using IPLocateNet.Inf.Data.DataSeeders;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IPLocateNet.Inf.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        CountrySovereigntySeeder.Seed(modelBuilder);
    }

    public DbSet<Sovereignty> Sovereignties => Set<Sovereignty>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<IpV4Range> IpV4Ranges => Set<IpV4Range>();
}
