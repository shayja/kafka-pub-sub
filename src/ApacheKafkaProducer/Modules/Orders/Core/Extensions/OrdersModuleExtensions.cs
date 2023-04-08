namespace ApacheKafkaProducer.Modules.Orders.Core.Extensions;
using EndPoints;

public static class OrdersModuleExtensions
{
    public static RouteGroupBuilder MapOrderApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", OrdersEndPoints.Get);
        //group.MapPost("/", OrdersEndPoints.CreateAsync);

        group.MapGet("/{id}", OrdersEndPoints.GetById);
        group.MapPost("/", OrdersEndPoints.CreateOrder);
        group.MapPut("/{id}", OrdersEndPoints.UpdateAsync);
        //group.MapDelete("/{id}", DeleteOrder);

        return group;
    }
}