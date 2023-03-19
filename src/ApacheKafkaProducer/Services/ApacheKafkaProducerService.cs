namespace ApacheKafkaProducer.Services;
using Confluent.Kafka;
using System;
using System.Net;
using Microsoft.Extensions.Configuration;

public class ApacheKafkaProducerService : IApacheKafkaProducerService
{
    private readonly string _topic;
    private readonly IConfigurationRoot _configurationRoot;
    public ApacheKafkaProducerService(IConfiguration configuration)
    {
        this._configurationRoot = (IConfigurationRoot)configuration ?? throw new ArgumentNullException(nameof(configuration));
        this._topic = _configurationRoot.GetSection("Kafka:Topic").Get<string>()!;
    }

    public async Task<bool> SendOrderRequest(string message)
    {
        if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

        Console.WriteLine($"SendOrderRequest: {message}");
        ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = _configurationRoot.GetSection("Kafka:BootstrapServers").Get<string>()!,
            ClientId = Dns.GetHostName()
        };

        try
        {
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var result = await producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
                Console.WriteLine($"Delivery Timestamp: {result.Timestamp.UtcDateTime}");
                //Console.WriteLine($"result: {System.Text.Json.JsonSerializer.Serialize(result)}");
                return await Task.FromResult(true);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured: {ex.Message}");
        }

        return await Task.FromResult(false);
    }

}