namespace ApacheKafkaProducer.Modules.Orders.Core.Domain;

public record CreateUpdateOrderDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }

    [Required]
    public string? Status { get; set; }
}
