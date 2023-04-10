namespace ApacheKafkaProducer.Modules.Orders.Ports;

public interface IOrderService
{
    Task<List<Order>> GetAsync();
    Task<Order?> GetAsync(string id);
    Task CreateAsync(Order newOrder);
    Task<Order?> CreateAsync(CreateUpdateOrderDto orderRequest, CancellationToken cancellation = default);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, Order updatedOrder);
}
