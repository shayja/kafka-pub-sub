namespace ApacheKafkaProducer.Modules.Cities.EndPoints;

public static class CitiesEndPoints
{
    internal static async Task<Results<NotFound, BadRequest, Ok<List<City>>>> Get(ICityService addressService)
    {
        var list = await addressService.GetAsync();
        if (!list.Any()) return TypedResults.NotFound();
        return TypedResults.Ok(list);
    }
}