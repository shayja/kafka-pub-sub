namespace ApacheKafkaProducer.Modules.Orders.Adapters;

public class ApacheKafkaProducerService : IApacheKafkaProducerService
{
    private readonly string _topic;
    private readonly IConfigurationRoot _configurationRoot;
    public ApacheKafkaProducerService(IConfiguration configuration)
    {
        this._configurationRoot = (IConfigurationRoot)configuration ?? throw new ArgumentNullException(nameof(configuration));
        // The Kafka topic we'll be using
        this._topic = _configurationRoot.GetSection("Kafka:Topic").Get<string>()!;
    }

    public async Task<bool> SendOrderRequest(string message, CancellationToken cancellation)
    {
        if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

        Console.WriteLine($"SendOrderRequest: {message}");

        // Create the producer configuration
        var config = new ProducerConfig
        {
            // The Kafka endpoint address
            BootstrapServers = _configurationRoot.GetSection("Kafka:BootstrapServers").Get<string>()!,
            ClientId = Dns.GetHostName()
        };

        try
        {
            // Create the producer
            using var producer = new ProducerBuilder<Null, string>(config)
            // Error handler
            .SetErrorHandler((_, e) =>
            {
                Console.WriteLine($"Kafka Error {e.Code}: {e.Reason}");
            })
            .Build();
            var result = await producer.ProduceAsync(_topic, new Message<Null, string> { Value = message }, cancellation).ConfigureAwait(false);

            Console.WriteLine($"Delivered {result.Value} on Partition: {result.Partition} with Offset: {result.Offset} to {result.TopicPartitionOffset}, Timestamp: {result.Timestamp.UtcDateTime}");
            //Console.WriteLine($"result: {System.Text.Json.JsonSerializer.Serialize(result)}");
            return await Task.FromResult(true).ConfigureAwait(false);
        }
        catch (ProduceException<Null, string> ex)
        {
            Console.WriteLine($"ProduceException occurred: {ex.Error.Reason}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ProduceException ArgumentException occurred: {ex.Message}");
        }

        return await Task.FromResult(false).ConfigureAwait(false);
    }

}