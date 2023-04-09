namespace ApacheKafkaConsumer.Core.Extensions;

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
        services.AddJsonConventions();
        services.AddSingleton<IHostedService, ApacheKafkaConsumerService>();
    }
}