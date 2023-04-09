namespace ApacheKafkaProducer.Modules.Orders.Core.Domain;

public record CreateUpdateOrderDto
{
    public string? Id { get; set; }
    public string? ProductId { get; set; }
    public string? CustomerId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    [Required]
    public string? Status { get; set; }
}
