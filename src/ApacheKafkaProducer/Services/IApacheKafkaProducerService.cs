namespace ApacheKafkaProducer.Services;

public interface IApacheKafkaProducerService
{
    Task<bool> SendOrderRequest(string message, CancellationToken cancellation);
}
