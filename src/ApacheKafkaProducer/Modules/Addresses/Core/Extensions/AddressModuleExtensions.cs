namespace ApacheKafkaProducer.Modules.Addresses.Core.Extensions;

public static class AddressModuleExtensions
{
    public static RouteGroupBuilder MapAddressApi(this RouteGroupBuilder group)
    {
        //group.MapGet("/", AddressesEndPoints.Get);
        group.MapGet("/{id}", AddressesEndPoints.Get);
        group.MapPost("/", AddressesEndPoints.CreateAsync);
        group.MapPut("/{id}", AddressesEndPoints.UpdateAsync);
        group.MapDelete("/{id}", AddressesEndPoints.RemoveAsync);

        return group;
    }
}