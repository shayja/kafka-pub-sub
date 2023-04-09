namespace ApacheKafkaConsumer.Core.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, HostBuilderContext hostContext)
    {
        var databaseSettings = hostContext.Configuration.GetSection(nameof(DatabaseSettings))!;
        var settings = new DatabaseSettings
        {
            ConnectionString = databaseSettings.GetValue<string>("ConnectionString")!,
            DatabaseName = databaseSettings.GetValue<string>("DatabaseName")!
        };
        services.AddSingleton<DatabaseSettings>(settings);

        // Add services to the container.
        ConfigureMiddleware(services);
        return services;
    }

    private static void ConfigureMiddleware(IServiceCollection services)
    {
        services.AddJsonConventions();
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<IHostedService, ApacheKafkaConsumerService>();
    }
}