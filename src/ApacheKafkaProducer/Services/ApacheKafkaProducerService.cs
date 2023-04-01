namespace ApacheKafkaProducer.Services;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

public class ApacheKafkaProducerService : IApacheKafkaProducerService
{
    private readonly string _topic;
    private readonly IConfigurationRoot _configurationRoot;
    public ApacheKafkaProducerService(IConfiguration configuration)
    {
        this._configurationRoot = (IConfigurationRoot)configuration ?? throw new ArgumentNullException(nameof(configuration));
        this._topic = _configurationRoot.GetSection("Kafka:Topic").Get<string>()!;
    }

    public async Task<bool> SendOrderRequest(string message, CancellationToken cancellation)
    {
        if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

        Console.WriteLine($"SendOrderRequest: {message}");
        var config = new ProducerConfig
        {
            BootstrapServers = _configurationRoot.GetSection("Kafka:BootstrapServers").Get<string>()!,
            ClientId = Dns.GetHostName()
        };

        try
        {
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var result = await producer.ProduceAsync(_topic, new Message<Null, string> { Value = message }, cancellation).ConfigureAwait(false);
            Console.WriteLine($"Delivered '{result.Value}' to '{result.TopicPartitionOffset}, Timestamp: {result.Timestamp.UtcDateTime}'");
            //Console.WriteLine($"result: {System.Text.Json.JsonSerializer.Serialize(result)}");
            return await Task.FromResult(true).ConfigureAwait(false);
        }
        catch (ProduceException<Null, string> ex)
        {
            Console.WriteLine($"ProduceException occurred: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ArgumentException occurred: {ex.Message}");
        }

        return await Task.FromResult(false).ConfigureAwait(false);
    }

}