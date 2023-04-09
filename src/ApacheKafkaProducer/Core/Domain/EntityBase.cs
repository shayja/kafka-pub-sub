namespace ApacheKafkaProducer.Core.Domain;

public abstract class EntityBase
{
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
}