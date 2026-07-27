using IPLocateNet.App.Exceptions;
using IPLocateNet.Inf.Data.LocalRepositories;
using Microsoft.EntityFrameworkCore;
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

        services.AddScoped<IPv4RangeRepository>();
    }

    public static async Task ConfigureHostAsync(IServiceProvider sp)
    {
        using var scope = sp.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await db.Database.MigrateAsync();
    }
}
