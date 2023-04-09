namespace ApacheKafkaProducer.Modules.Orders.Core.Domain;

public class OrderLineItem
{
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal? ShippingPrice { get; set; }
    public decimal TotalPrice { get; set; }
}