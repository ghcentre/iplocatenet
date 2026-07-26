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

            using var scope = host.Services.CreateScope();
            var worker = scope.ServiceProvider.GetRequiredService<Worker>();
            await worker.RunAsync(CancellationToken.None);

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
        DataLayerConfigurator.ConfigureServices(services, env.IsDevelopment(), () => configuration.GetConnectionString("Default"));
        LoggingConfigurator.ConfigureServices(services, configuration);
        services.AddTransient<Worker>();
    }

    private static async Task ConfigureHostAsync(IHost host)
    {
        await DataLayerConfigurator.ConfigureHostAsync(host.Services);
    }
}
