namespace ApacheKafkaProducer.Modules.Orders;

public class OrdersModule : IModule
{
    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        services.AddSingleton<IApacheKafkaProducerService, ApacheKafkaProducerService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("api/v1/order")
            .MapOrderApi()
            .WithTags("Order");

        return endpoints;
    }
}
