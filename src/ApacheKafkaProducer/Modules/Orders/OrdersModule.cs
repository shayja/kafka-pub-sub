namespace ApacheKafkaProducer.Modules.Orders;
using ApacheKafkaProducer.Modules.Orders.EndPoints;
public static class OrdersModule
{
    public static void MapOrdersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGroup("api/v1/order")
            .MapOrderApi()
            .WithTags("Order");
    }

    public static RouteGroupBuilder MapOrderApi(this RouteGroupBuilder group)
    {
        // group.MapGet("/", GetAllTodos);
        // group.MapGet("/{id}", GetTodo);
        group.MapPost("/", OrdersEndPoints.CreateOrder);
        // group.MapPut("/{id}", UpdateTodo);
        // group.MapDelete("/{id}", DeleteTodo);

        return group;
    }



}
