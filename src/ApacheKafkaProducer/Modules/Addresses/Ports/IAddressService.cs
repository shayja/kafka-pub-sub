namespace ApacheKafkaProducer.Modules.Addresses.Ports;

public interface IAddressService
{
    Task<List<Address>> GetAsync(string customerId);

    //Task<Address?> GetAsync(string id);

    Task CreateAsync(Address newAddress);

    Task UpdateAsync(string id, Address updatedAddress);

    Task RemoveAsync(string id);
}
