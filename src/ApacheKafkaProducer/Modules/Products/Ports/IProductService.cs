namespace ApacheKafkaProducer.Modules.Products.Ports;

public interface IProductService
{
    Task<List<Product>> GetAsync();

    Task<Product?> GetAsync(string id);

    Task CreateAsync(Product newProduct);

    Task UpdateAsync(string id, Product updatedProduct);

    Task RemoveAsync(string id);
}
