namespace ApacheKafkaProducer.Modules.Cities;

public class CitiesModule : IModule
{
    public string Name => "City";

    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        services.AddSingleton<ICityService, CityService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {

        endpoints.MapGroup($"api/v1/{Name.ToLower()}")
            .MapCityApi()
            .WithTags(this.Name);

        return endpoints;
    }
}
