namespace ApacheKafkaProducer.Modules.Orders.Adapters;
using MongoDB.Driver;

public class OrderService : IOrderService
{
    private readonly IMongoCollection<Order> _ordersCollection;

    public OrderService(IOptions<DatabaseSettings> databaseSettings)
    {
        if (databaseSettings?.Value is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName!);
        _ordersCollection = mongoDatabase.GetCollection<Order>("orders");
    }

    public async Task<List<Order>> GetAsync() =>
        await _ordersCollection.Find(_ => true).ToListAsync();

    public async Task<Order?> GetAsync(string id) =>
        await _ordersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Order newOrder) =>
        await _ordersCollection.InsertOneAsync(newOrder);

    public async Task UpdateAsync(string id, Order updatedOrder) =>
        await _ordersCollection.ReplaceOneAsync(x => x.Id == id, updatedOrder);

    public async Task RemoveAsync(string id) =>
        await _ordersCollection.DeleteOneAsync(x => x.Id == id);
}