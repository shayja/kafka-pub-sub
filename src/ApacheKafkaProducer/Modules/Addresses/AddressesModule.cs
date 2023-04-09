namespace ApacheKafkaProducer.Modules.Addresses;

public class AddressesModule : IModule
{
    public string Name => "Address";

    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        services.AddSingleton<IAddressService, AddressService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {

        endpoints.MapGroup($"api/v1/{Name.ToLower()}")
            .MapAddressApi()
            .WithTags(this.Name);

        return endpoints;
    }
}
