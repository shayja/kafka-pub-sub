namespace ApacheKafkaProducer.Modules.Products.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public ProductStatus Status { get; set; }
}