namespace ApacheKafkaProducer.Modules.Customers;

public class CustomersModule : IModule
{
    public string Name => "Customer";

    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        services.AddSingleton<ICustomerService, CustomersService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {

        endpoints.MapGroup($"api/v1/{Name.ToLower()}")
            .MapCustomerApi()
            .WithTags(this.Name);

        return endpoints;
    }
}
