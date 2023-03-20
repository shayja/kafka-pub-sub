namespace ApacheKafkaConsumer.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Add services to the container.
        ConfigureMiddleware(services);
        return services;
    }

    private static void ConfigureMiddleware(IServiceCollection services)
    {
        services.AddSingleton<IHostedService, ApacheKafkaConsumerService>();
    }
}