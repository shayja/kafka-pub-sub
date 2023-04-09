namespace ApacheKafkaProducer.Modules.Cities.Ports;

public interface ICityService
{
    Task<List<City>> GetAsync();
}
