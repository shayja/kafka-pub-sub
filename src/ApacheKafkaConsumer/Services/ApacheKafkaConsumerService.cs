namespace ApacheKafkaConsumer.Services;

public class ApacheKafkaConsumerService : IHostedService
{
    private readonly string _topic;
    private readonly IConfigurationRoot _configurationRoot;
    private readonly IOrderService _orderService;
    public ApacheKafkaConsumerService(IConfiguration configurationRoot, IOrderService orderService)
    {
        this._configurationRoot = (IConfigurationRoot)configurationRoot ?? throw new ArgumentNullException(nameof(configurationRoot));
        this._topic = configurationRoot.GetSection("Kafka:Topic").Get<string>()!;
        this._orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Create the consumer configuration
        var config = new ConsumerConfig
        {
            GroupId = _configurationRoot.GetSection("Kafka:GroupId").Get<string>()!,
            BootstrapServers = _configurationRoot.GetSection("Kafka:BootstrapServers").Get<string>()!,
            AutoOffsetReset = AutoOffsetReset.Earliest,
        };

        try
        {
            // Create the consumer
            using var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
            // Subscribe to the Kafka topic
            consumerBuilder.Subscribe(_topic);
            var cancelToken = new CancellationTokenSource();

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumer = consumerBuilder.Consume(cancelToken.Token);
                        var messageAsString = consumer.Message.Value;
                        var orderRequest = JsonSerializer.Deserialize<Order>(messageAsString);
                        if (orderRequest is null)
                        {
                            Console.WriteLine($"orderRequest is null");
                        }
                        else
                        {
                            Console.WriteLine($"Consumed message: Order: {messageAsString} at: '{consumer.TopicPartitionOffset}");
                            Task.Run(async () => await this._orderService.CreateAsync(orderRequest));
                        }

                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occurred: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                consumerBuilder.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Task.CompletedTask;
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
