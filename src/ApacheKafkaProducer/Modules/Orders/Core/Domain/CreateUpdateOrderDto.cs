namespace ApacheKafkaProducer.Modules.Orders.Core.Domain;

public record CreateUpdateOrderDto
{
    public string? Id { get; set; }
    [Required]
    public string CustomerId { get; set; } = null!;
    public string? AddressId { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal TotalPrice { get; set; }
    public int? SupplyMethod { get; set; }
    public List<OrderLineItemDto> LineItems { get; set; } = null!;
}

public class OrderLineItemDto
{
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal? ShippingPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
