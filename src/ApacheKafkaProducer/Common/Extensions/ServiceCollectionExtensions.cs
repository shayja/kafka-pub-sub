namespace ApacheKafkaProducer.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.ConfigureSwagger();
        // Add Middleware.
        services.ConfigureMiddleware();
        return services;
    }

    public static void ConfigureAppRouting(this WebApplication app)
    {
        app.MapOrdersEndpoints();
        //app.MapGet("/", () => "Hello World!");
        //app.MapGet("{message:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}", () => "Inline Regex Constraint Matched");
    }


    private static void ConfigureMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<IApacheKafkaProducerService, ApacheKafkaProducerService>();
    }

    public static void ConfigureAppMiddleware(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }

    private static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}