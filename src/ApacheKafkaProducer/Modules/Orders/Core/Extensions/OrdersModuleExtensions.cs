namespace ApacheKafkaProducer.Modules.Orders.Core.Extensions;
using EndPoints;

public static class OrdersModuleExtensions
{
    public static RouteGroupBuilder MapOrderApi(this RouteGroupBuilder group)
    {
        // group.MapGet("/", GetAllOrders);
        // group.MapGet("/{id}", GetOrder);
        group.MapPost("/", OrdersEndPoints.CreateOrder);
        // group.MapPut("/{id}", UpdateOrder);
        // group.MapDelete("/{id}", DeleteOrder);

        return group;
    }
}