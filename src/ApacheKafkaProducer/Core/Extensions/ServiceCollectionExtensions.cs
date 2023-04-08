namespace ApacheKafkaProducer.Core.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.ConfigureSwagger();
        services.AddJsonConventions();

        // Add Middleware.
        services.ConfigureMiddleware();
        return services;
    }

    public static IServiceCollection ConfigureModules(this IServiceCollection services)
    {
        services.RegisterModules();
        return services;
    }

    private static void ConfigureMiddleware(this IServiceCollection services)
    {
    }
}