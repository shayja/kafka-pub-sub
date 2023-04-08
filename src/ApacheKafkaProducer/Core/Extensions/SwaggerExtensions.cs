namespace ApacheKafkaProducer.Core.Extensions;
using Microsoft.OpenApi.Models;

internal static class SwaggerExtensions
{
    internal static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Minimal API & Kafka",
                Description = "A project using the latest version minimal API with Kafka",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "Shay Jacoby",
                    Url = new Uri("https://github.com/shayja")
                }
            });
        });

    }
}