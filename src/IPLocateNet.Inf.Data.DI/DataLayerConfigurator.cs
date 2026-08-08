using IPLocateNet.App.Exceptions;
using IPLocateNet.App.Repositories.Abstractions;
using IPLocateNet.Inf.Data.LocalRepositories;
using IPLocateNet.Inf.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace IPLocateNet.Inf.Data.DI;

public static class DataLayerConfigurator
{
    public static void ConfigureServices(IServiceCollection services, bool isDevelopmentEnvironment, Func<string?> connectionStringFactory)
    {
        services.AddDbContext<AppDbContext>(
            (sp, options) =>
            {
                if (connectionStringFactory() is not string connectionString || string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidAppConfigurationException("Connection string is empty.");
                }

                options.UseSqlite(connectionString);

                if (isDevelopmentEnvironment)
                {
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            });
        
        services.AddSingleton(
            sp =>
            new Func<IDbContextTransaction, IUnitOfWorkTransaction>(dbtran => new UnitOfWorkTransaction(dbtran)));
        services.AddScoped<IUnitOfWork>(
            sp =>
            new UnitOfWork(
                sp.GetRequiredService<AppDbContext>(),
                sp.GetRequiredService<Func<IDbContextTransaction, IUnitOfWorkTransaction>>()));

        services.AddScoped<IPv4RangeRepository>();
        services.AddScoped<CountryRepository>();
    }

    public static async Task ConfigureHostAsync(IServiceProvider sp)
    {
        using var scope = sp.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.MigrateAsync();
    }
}
