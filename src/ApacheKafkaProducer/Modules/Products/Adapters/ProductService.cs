namespace ApacheKafkaProducer.Modules.Products.Adapters;
using MongoDB.Driver;

public class ProductsService : IProductService
{
    private readonly IMongoCollection<Product> _productsCollection;

    public ProductsService(IOptions<DatabaseSettings> databaseSettings)
    {
        if (databaseSettings?.Value is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName!);
        _productsCollection = mongoDatabase.GetCollection<Product>("products");
    }

    public async Task<List<Product>> GetAsync() =>
        await _productsCollection.Find(_ => true).ToListAsync();

    public async Task<Product?> GetAsync(string id) =>
        await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Product newProduct) =>
        await _productsCollection.InsertOneAsync(newProduct);

    public async Task UpdateAsync(string id, Product updatedProduct) =>
        await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

    public async Task RemoveAsync(string id)
    {
        var item = await GetAsync(id);
        if (item is null) return;
        item.Status = ProductStatus.Deleted;
        await UpdateAsync(id, item);
        //await _productsCollection.DeleteOneAsync(x => x.Id == id);
    }

}