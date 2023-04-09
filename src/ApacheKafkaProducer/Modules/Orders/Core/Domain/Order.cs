namespace ApacheKafkaProducer.Modules.Orders.Core.Domain;

public class Order : EntityBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string ProductId { get; set; } = null!;
    public string CustomerId { get; set; } = null!;
    public int Quantity { get; set; } = 1;
    public decimal Price { get; set; }
    public OrderStatus? Status { get; set; }
}


