namespace ApacheKafkaProducer.Modules.Customers.EndPoints;

public static class CustomersEndPoints
{
    internal static async Task<Results<NotFound, Ok<List<Customer>>>> Get(ICustomerService customersService)
    {
        var list = await customersService.GetAsync();
        if (!list.Any()) return TypedResults.NotFound();
        return TypedResults.Ok(list);
    }

    internal static async Task<Results<NotFound, BadRequest, Ok<Customer>>> GetById(string customerId, ICustomerService customersService)
    {
        if (!customerId.IdValidObjectId()) return TypedResults.BadRequest();
        var item = await customersService.GetAsync(customerId);
        if (item is null) return TypedResults.NotFound();
        return TypedResults.Ok(item);
    }

    internal static async Task CreateAsync(Customer newCustomer, ICustomerService customersService) =>
        await customersService.CreateAsync(newCustomer);

    internal static async Task UpdateAsync(string id, Customer updatedCustomer, ICustomerService customersService) =>
        await customersService.UpdateAsync(id, updatedCustomer);

    internal static async Task RemoveAsync(string id, ICustomerService customersService) =>
        await customersService.RemoveAsync(id);

}