namespace ApacheKafkaProducer.Modules.Customers.Core.Domain;

public class Customer : EntityBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public bool? AgreeMarketing { get; set; }
    public CustomerStatus Status { get; set; }
}