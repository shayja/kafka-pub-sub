namespace ApacheKafkaProducer.Modules.Customers.Core.Extensions;

public static class CustomersModuleExtensions
{
    public static RouteGroupBuilder MapCustomerApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", CustomersEndPoints.Get);
        group.MapGet("/{customerId}", CustomersEndPoints.GetById);
        group.MapPost("/", CustomersEndPoints.CreateAsync);
        group.MapPut("/{id}", CustomersEndPoints.UpdateAsync);
        group.MapDelete("/{id}", CustomersEndPoints.RemoveAsync);

        return group;
    }
}