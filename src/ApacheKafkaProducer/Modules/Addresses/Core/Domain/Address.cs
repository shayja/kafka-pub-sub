namespace ApacheKafkaProducer.Modules.Addresses.Core.Domain;

public class Address : EntityBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string CustomerId { get; set; } = null!;
    public string? RecipientName { get; set; }
    public string? CompanyName { get; set; }
    public string? StreetName { get; set; }
    public string? HouseNumber { get; set; }
    public string? CityId { get; set; }
    public string? CityName { get; set; }
    public string? Floor { get; set; }
    public string? Apartment { get; set; }
    public string? Entrance { get; set; }
    public string? ZipCode { get; set; }
    public bool IsMain { get; set; }
    public bool IsActive { get; set; }
}
