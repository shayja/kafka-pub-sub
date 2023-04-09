namespace ApacheKafkaConsumer.Models;

public class Order : EntityBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string ProductId { get; set; } = null!;
    public string CustomerId { get; set; } = null!;
    public string AddressId { get; set; } = null!;
    public List<OrderLineItem> LineItems { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus? Status { get; set; }
    public SupplyMethod? SupplyMethod { get; set; }
}
