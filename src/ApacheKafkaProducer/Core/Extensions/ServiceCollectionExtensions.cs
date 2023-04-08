namespace ApacheKafkaProducer.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.ConfigureSwagger();
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


    private static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Description = "Minimal API & Kafka",
                Title = "A project using the latest version minimal API with Kafka",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "Shay Jacoby",
                    Url = new Uri("https://github.com/aaaaaaaaaaaaaaaaaa")
                }
            });
        });

    }
}