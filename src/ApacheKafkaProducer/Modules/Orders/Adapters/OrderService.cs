namespace ApacheKafkaProducer.Modules.Orders.Adapters;

public class OrderService : IOrderService
{
    private readonly IMongoCollection<Order> _ordersCollection;
    private readonly IApacheKafkaProducerService _apacheKafkaProducerService;
    private bool _useQueue = false;

    public OrderService(IOptions<DatabaseSettings> databaseSettings, IApacheKafkaProducerService apacheKafkaProducerService)
    {
        if (databaseSettings.Value is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _ordersCollection = mongoDatabase.GetCollection<Order>("orders");
        _apacheKafkaProducerService = apacheKafkaProducerService ?? throw new ArgumentNullException(nameof(apacheKafkaProducerService));
        _useQueue = databaseSettings.Value.UseQueue;
    }

    public async Task<List<Order>> GetAsync() =>
        await _ordersCollection.Find(_ => true).ToListAsync();

    public async Task<Order?> GetAsync(string id) =>
        await _ordersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<Order?> CreateAsync(CreateUpdateOrderDto orderRequest, CancellationToken cancellation = default)
    {
        if (_useQueue)
        {
            var message = JsonSerializer.Serialize(orderRequest);
            await _apacheKafkaProducerService.SendOrderRequest(message, cancellation).ConfigureAwait(false);
            return null;
        }

        var order = new Order
        {
            AddressId = orderRequest.AddressId!,
            CustomerId = orderRequest.CustomerId,
            ShippingCost = orderRequest.ShippingCost,
            Status = OrderStatus.AwaitingPayment,
            SupplyMethod = (SupplyMethod)orderRequest.SupplyMethod!,
            TotalPrice = orderRequest.TotalPrice,
            LineItems = orderRequest.LineItems.Select(x => new OrderLineItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                ShippingPrice = x.ShippingPrice,
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice
            }).ToList()
        };
        await CreateAsync(order);
        return order;
    }

    public async Task CreateAsync(Order newOrder) =>
        await _ordersCollection.InsertOneAsync(newOrder);

    public async Task UpdateAsync(string id, Order updatedOrder) =>
        await _ordersCollection.ReplaceOneAsync(x => x.Id == id, updatedOrder);

    public async Task RemoveAsync(string id) =>
        await _ordersCollection.DeleteOneAsync(x => x.Id == id);
}