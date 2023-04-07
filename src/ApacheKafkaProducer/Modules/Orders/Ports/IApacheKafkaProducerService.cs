namespace ApacheKafkaProducer.Modules.Orders.Ports;

public interface IApacheKafkaProducerService
{
    Task<bool> SendOrderRequest(string message, CancellationToken cancellation);
}
