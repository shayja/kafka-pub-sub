namespace ApacheKafkaConsumer.Services;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Models;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


public class ApacheKafkaConsumerService : IHostedService
{
    private readonly string _topic;
    private readonly IConfigurationRoot _configurationRoot;
    public ApacheKafkaConsumerService(IConfiguration configurationRoot)
    {
        this._configurationRoot = (IConfigurationRoot)configurationRoot ?? throw new ArgumentNullException(nameof(configurationRoot));
        this._topic = configurationRoot.GetSection("Kafka:Topic").Get<string>()!;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var config = new ConsumerConfig
        {
            GroupId = _configurationRoot.GetSection("Kafka:GroupId").Get<string>()!,
            BootstrapServers = _configurationRoot.GetSection("Kafka:BootstrapServers").Get<string>()!,
            AutoOffsetReset = AutoOffsetReset.Earliest,

        };

        try
        {
            using var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
            consumerBuilder.Subscribe(_topic);
            var cancelToken = new CancellationTokenSource();

            try
            {
                while (true)
                {
                    var consumer = consumerBuilder.Consume(cancelToken.Token);
                    var orderRequest = JsonSerializer.Deserialize<OrderProcessingRequest>(consumer.Message.Value);
                    Console.WriteLine($"Processing Order Id: {orderRequest!.OrderId}");
                }
            }
            catch (OperationCanceledException)
            {
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
