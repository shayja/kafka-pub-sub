namespace ApacheKafkaProducer.Modules.Orders.Ports;

public interface IOrderService
{
    Task CreateAsync(Order newOrder);
    Task<List<Order>> GetAsync();
    Task<Order?> GetAsync(string id);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, Order updatedOrder);
}
