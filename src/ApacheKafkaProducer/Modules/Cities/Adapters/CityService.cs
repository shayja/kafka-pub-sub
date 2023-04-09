namespace ApacheKafkaProducer.Modules.Cities.Adapters;

public class CityService : ICityService
{
    private readonly IMongoCollection<City> _cityCollection;

    public CityService(IOptions<DatabaseSettings> databaseSettings)
    {
        if (databaseSettings.Value is null) throw new ArgumentNullException(nameof(databaseSettings));
        var mongoDbClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoDbClient.GetDatabase(databaseSettings.Value.DatabaseName);
        _cityCollection = mongoDatabase.GetCollection<City>("cities");
    }

    public async Task<List<City>> GetAsync() =>
       await _cityCollection.Find(_ => true).ToListAsync();
}