namespace ApacheKafkaProducer.Modules.Orders.Adapters;

public class OrderService : IOrderService
{
    private readonly IMongoCollection<Order> _ordersCollection;

    public OrderService(IOptions<DatabaseSettings> databaseSettings)
    {
        if (databaseSettings.Value is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _ordersCollection = mongoDatabase.GetCollection<Order>("orders");
    }

    public async Task CreateAsync(List<OrderLineItemDto> newOrders) =>
        await _ordersCollection.Inser(newOrder);

}