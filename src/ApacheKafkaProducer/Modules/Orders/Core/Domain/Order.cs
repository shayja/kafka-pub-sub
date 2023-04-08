namespace ApacheKafkaProducer.Modules.Orders.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; } = 1;
    public decimal Price { get; set; }
    public string Author { get; set; } = null!;
}