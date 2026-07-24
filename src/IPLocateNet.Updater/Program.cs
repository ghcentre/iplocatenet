using IPLocateNet.Inf.Data.DI;
using IPLocateNet.Inf.Logging.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IPLocateNet.Updater;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

        var host = builder.Build();

        using var loggerBag = LoggingConfigurator.CreateStartupLogger<Program>(host.Services);
        var logger = loggerBag.Value;

        try
        {
            await ConfigureHostAsync(host);

            logger.LogTrace("Trace");
            logger.LogDebug("Debug");
            logger.LogInformation("Information");
            logger.LogWarning("Warning");
            logger.LogError("Error");

            return ExitCode.Success;
        }
        catch (Exception exception)
        {
            logger?.LogCritical(exception, "Fatal exception");
            return ExitCode.GenericError;
        }
    }

    private static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration, IHostEnvironment env)
    {
        configuration.SetBasePath(Directory.GetCurrentDirectory());
        DataLayerConfigurator.ConfigureServices(services, () => configuration.GetConnectionString("Default"));
        LoggingConfigurator.ConfigureServices(services, configuration);
    }

    private static async Task ConfigureHostAsync(IHost host)
    {
        await DataLayerConfigurator.ConfigureHostAsync(host.Services);
    }
}
