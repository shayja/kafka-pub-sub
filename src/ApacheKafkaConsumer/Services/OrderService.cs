namespace ApacheKafkaConsumer.Services;

public class OrderService : IOrderService
{
    private readonly IMongoCollection<Order> _ordersCollection;

    public OrderService(DatabaseSettings databaseSettings)
    {
        if (databaseSettings is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoClient = new MongoClient(databaseSettings.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        _ordersCollection = mongoDatabase.GetCollection<Order>("orders");
    }

    public async Task CreateAsync(Order newOrders) =>
        await _ordersCollection.InsertOneAsync(newOrders);

}