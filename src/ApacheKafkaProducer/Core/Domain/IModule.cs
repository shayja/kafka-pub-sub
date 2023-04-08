namespace ApacheKafkaProducer.Core.Domain;

public interface IModule
{
    string Name { get; }
    IServiceCollection RegisterModules(IServiceCollection builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}