namespace ApacheKafkaProducer.Modules.Addresses.Adapters;

public class AddressService : IAddressService
{
    private readonly IMongoCollection<Address> _addressCollection;

    public AddressService(IOptions<DatabaseSettings> databaseSettings)
    {
        if (databaseSettings.Value is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoDbClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoDbClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _addressCollection = mongoDatabase.GetCollection<Address>("addresses");
    }

    public async Task<List<Address>> GetAsync(string customerId) =>
        await _addressCollection.Find(x => x.CustomerId == customerId && x.IsActive).ToListAsync();

    // public async Task<Address?> GetAsync(string id) =>
    //     await _addressCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Address newAddress) =>
        await _addressCollection.InsertOneAsync(newAddress);

    public async Task UpdateAsync(string id, Address updatedAddress) =>
        await _addressCollection.ReplaceOneAsync(x => x.Id == id, updatedAddress);

    public async Task RemoveAsync(string id)
    {
        var item = await _addressCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (item is null) return;
        item.IsActive = false;
        await UpdateAsync(id, item);
        //await _addressCollection.DeleteOneAsync(x => x.Id == id);
    }

}