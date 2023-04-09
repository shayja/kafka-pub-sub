namespace ApacheKafkaProducer.Modules.Customers.Adapters;

public class CustomersService : ICustomerService
{
    private readonly IMongoCollection<Customer> _customersCollection;

    public CustomersService(IOptions<DatabaseSettings> databaseSettings)
    {
        if (databaseSettings.Value is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoDbClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoDbClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _customersCollection = mongoDatabase.GetCollection<Customer>("customers");
    }

    public async Task<List<Customer>> GetAsync() =>
        await _customersCollection.Find(_ => true).ToListAsync();

    public async Task<Customer?> GetAsync(string id) =>
        await _customersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Customer newCustomer) =>
        await _customersCollection.InsertOneAsync(newCustomer);

    public async Task UpdateAsync(string id, Customer updatedCustomer) =>
        await _customersCollection.ReplaceOneAsync(x => x.Id == id, updatedCustomer);

    public async Task RemoveAsync(string id)
    {
        var item = await GetAsync(id);
        if (item is null) return;
        item.Status = CustomerStatus.Deleted;
        await UpdateAsync(id, item);
        //await _customersCollection.DeleteOneAsync(x => x.Id == id);
    }

}