namespace ApacheKafkaProducer.Modules.Customers.Core.Domain;

public enum CustomerStatus
{
    Approved = 1,
    AwaitingApproval = 2,
    NotActive = 3,
    Deleted = 4,
}