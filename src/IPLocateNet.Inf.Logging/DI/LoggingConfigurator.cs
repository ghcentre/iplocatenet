using Ample.Core.Disposables;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace IPLocateNet.Inf.Logging.DI;

public static class LoggingConfigurator
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog(
            (sp, config) =>
            {
                config.ReadFrom.Configuration(configuration);
            });
    }

    public static DisposableBag<ILogger<T>> CreateStartupLogger<T>(IServiceProvider sp)
    {
        var scope = sp.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<T>>();

        var bag = DisposableBag.For(logger).With(scope);
        return bag;
    }
}