namespace ApacheKafkaProducer.Modules.Orders.EndPoints;

public static partial class OrdersEndPoints
{
    internal static async Task<Results<BadRequest, Ok<bool>>> CreateOrder(OrderRequest? orderRequest, IApacheKafkaProducerService apacheKafkaProducerService, CancellationToken cancellation = default)
    {
        if (orderRequest is null) return TypedResults.BadRequest(); //"Order is null"
        if (orderRequest.OrderId <= 0) return TypedResults.BadRequest(); //$"OrderId {orderRequest.OrderId} is not valid"
        var message = JsonSerializer.Serialize(orderRequest);
        var res = await apacheKafkaProducerService.SendOrderRequest(message, cancellation).ConfigureAwait(false);
        return TypedResults.Ok(res);
    }
}