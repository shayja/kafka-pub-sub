namespace ApacheKafkaProducer.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddRouting(options => options.LowercaseUrls = true);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureCors();


        // Add the memory cache services.
        //services.AddMemoryCache();
        ConfigureMiddleware(services);
        return services;
    }

    public static void ConfigureApp(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
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

}