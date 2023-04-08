namespace ApacheKafkaProducer.Core.Extensions;
internal static class WebApplicationExtensions
{
    public static void ConfigureAppMiddleware(this WebApplication app)
    {
        app.ConfigureSwagger();
    }

    private static void ConfigureSwagger(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}

