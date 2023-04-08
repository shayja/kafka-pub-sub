namespace ApacheKafkaProducer.Core.Domain;

public interface IModule
{
    IServiceCollection RegisterModules(IServiceCollection builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}