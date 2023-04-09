namespace ApacheKafkaProducer.Modules.Orders.Core.Domain;

public enum OrderStatus
{
    AwaitingPayment = 1,
    New = 2,
    Failed = 3,
    Cancelled = 4,
    ReadyToDelivery = 5,
    PickInProgress = 6,
    ReadyToPickup = 7,
    CanceCompletelled = 8,
}