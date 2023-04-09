namespace ApacheKafkaProducer.Modules.Cities.Core.Extensions;

public static class CityModuleExtensions
{
    public static RouteGroupBuilder MapCityApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", CitiesEndPoints.Get);
        return group;
    }
}