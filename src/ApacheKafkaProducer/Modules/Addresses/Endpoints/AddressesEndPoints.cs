namespace ApacheKafkaProducer.Modules.Addresses.EndPoints;

public static class AddressesEndPoints
{
    internal static async Task<Results<NotFound, BadRequest, Ok<List<Address>>>> Get(string id, IAddressService addressService)
    {
        if (!id.IdValidObjectId()) return TypedResults.BadRequest();
        var list = await addressService.GetAsync(id);
        if (!list.Any()) return TypedResults.NotFound();
        return TypedResults.Ok(list);
    }

    /*
        internal static async Task<Results<NotFound, BadRequest, Ok<Address>>> GetById(string id, IAddressService addressService)
        {
            if (!id.IdValidObjectId()) return TypedResults.BadRequest();
            var item = await addressService.GetAsync(id);
            if (item is null) return TypedResults.NotFound();
            return TypedResults.Ok(item);
        }
    */
    internal static async Task CreateAsync(Address newAddress, IAddressService addressService) =>
        await addressService.CreateAsync(newAddress);

    internal static async Task UpdateAsync(string id, Address updatedAddress, IAddressService addressService) =>
        await addressService.UpdateAsync(id, updatedAddress);

    internal static async Task RemoveAsync(string id, IAddressService addressService) =>
        await addressService.RemoveAsync(id);

}