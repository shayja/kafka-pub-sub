namespace ApacheKafkaProducer.Modules.Orders.EndPoints;

public static class OrdersEndPoints
{
    internal static async Task<Results<BadRequest, Created<Order>, Ok<bool>>> CreateOrder(CreateUpdateOrderDto? orderRequest, IOrderService ordersService, CancellationToken cancellation = default)
    {
        if (orderRequest is null) return TypedResults.BadRequest(); //"Order is null"
        if (orderRequest.CustomerId is null) return TypedResults.BadRequest(); //$"OrderId {orderRequest.OrderId} is not valid"
        var order = await ordersService.CreateAsync(orderRequest);
        if (order is null)
        {
            return TypedResults.Ok(true);
        }
        return TypedResults.Created($"/order/{orderRequest.Id}", order);
    }

    internal static async Task<Results<NotFound, Ok<List<Order>>>> Get(IOrderService ordersService)
    {
        var list = await ordersService.GetAsync();
        if (!list.Any()) return TypedResults.NotFound();
        return TypedResults.Ok(list);
    }

    internal static async Task<Results<NotFound, BadRequest, Ok<Order>>> GetById(string id, IOrderService ordersService)
    {
        if (!id.IdValidObjectId()) return TypedResults.BadRequest();
        var item = await ordersService.GetAsync(id);
        if (item is null) return TypedResults.NotFound();
        return TypedResults.Ok(item);
    }

    //internal static async Task CreateAsync(Order newOrder, IOrderService ordersService) =>
    //    await ordersService.CreateAsync(newOrder);
    //return CreatedAtAction(nameof(Get), new { id = newOrder.Id }, newOrder);

    internal static async Task UpdateAsync(string id, Order updatedOrder, IOrderService ordersService) =>
          await ordersService.UpdateAsync(id, updatedOrder);

}