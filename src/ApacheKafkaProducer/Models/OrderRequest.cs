namespace ApacheKafkaProducer.Models;

public record OrderRequest
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }

    [Required]
    public string? Status { get; set; }
}
