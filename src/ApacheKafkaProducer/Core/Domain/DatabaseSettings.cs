namespace ApacheKafkaProducer.Core.Domain;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}