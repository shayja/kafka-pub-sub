namespace ApacheKafkaProducer.Modules.Products;

public class ProductsModule : IModule
{
    public string Name => "Product";

    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductsService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {

        endpoints.MapGroup($"api/v1/{Name.ToLower()}")
            .MapProductApi()
            .WithTags(this.Name);

        return endpoints;
    }
}
