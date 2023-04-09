namespace ApacheKafkaProducer.Modules.Products.Core.Extensions;

public static class ProductsModuleExtensions
{
    public static RouteGroupBuilder MapProductApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", ProductsEndPoints.Get);
        group.MapGet("/{id}", ProductsEndPoints.GetById);
        group.MapPost("/", ProductsEndPoints.CreateAsync);
        group.MapPut("/{id}", ProductsEndPoints.UpdateAsync);
        group.MapDelete("/{id}", ProductsEndPoints.RemoveAsync);

        return group;
    }
}