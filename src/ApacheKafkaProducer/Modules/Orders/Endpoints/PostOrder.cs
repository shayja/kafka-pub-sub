namespace ApacheKafkaProducer.Modules.Orders.EndPoints;
using ApacheKafkaProducer.Modules.Orders.Core;

public static class OrdersEndPoints
{
    internal static async Task<Results<BadRequest, Ok<bool>>> CreateOrder(OrderRequest? orderRequest, IApacheKafkaProducerService apacheKafkaProducerService, CancellationToken cancellation = default)
    {
        if (orderRequest is null) TypedResults.BadRequest("Order is null");
        var message = JsonSerializer.Serialize(orderRequest);
        var res = await apacheKafkaProducerService.SendOrderRequest(message, cancellation).ConfigureAwait(false);
        return TypedResults.Ok(res);
    }
}