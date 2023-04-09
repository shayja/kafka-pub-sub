namespace ApacheKafkaConsumer.Services;

public interface IOrderService
{
    Task CreateAsync(Order newOrders);
}