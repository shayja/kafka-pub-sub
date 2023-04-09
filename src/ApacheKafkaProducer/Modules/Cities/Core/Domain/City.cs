namespace ApacheKafkaProducer.Modules.Cities.Core.Domain;

public class City
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
}