namespace ApacheKafkaConsumer.Models;

public class OrderProcessingRequest
{
    public string? Id { get; set; }
    public string? ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Status { get; set; }
}
