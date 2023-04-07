namespace ApacheKafkaProducer.Common.Extensions;

using Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.ConfigureApiVersioning();
        services.ConfigureCors();


        // Add the memory cache services.
        //services.AddMemoryCache();

        // Add Middleware.
        ConfigureMiddleware(services);
        return services;
    }

    public static void ConfigureApp(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //User Reverse to show V2 first in Swagger:
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions/*.Reverse()*/)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }
            });
        }

        app.MapControllers();

        /*
        //This middleware is used to redirects HTTP requests to HTTPS.  
        app.UseHttpsRedirection();   

        //This middleware is used to returns static files and short-circuits further request processing. Static files aren't compressed by Static File Middleware.
        app.UseStaticFiles();  

        //This middleware is used to route requests.   
        app.UseRouting();   

        app.UseResponseCompression();

        */

        //This middleware is used to authorizes a user to access secure resources.  
        app.UseAuthorization();

    }

    private static void ConfigureMiddleware(IServiceCollection services)
    {
        services.AddSingleton<IApacheKafkaProducerService, ApacheKafkaProducerService>();
    }

    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }

    private static void ConfigureApiVersioning(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureOptions<ConfigureSwaggerOptions>();

        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        });

        // Add ApiExplorer to discover versions
        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
    }

}