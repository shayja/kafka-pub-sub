namespace ApacheKafkaProducer.Modules.Products.EndPoints;

public static class ProductsEndPoints
{
    internal static async Task<Results<NotFound, Ok<List<Product>>>> Get(IProductService productsService)
    {
        var list = await productsService.GetAsync();
        if (!list.Any()) return TypedResults.NotFound();
        return TypedResults.Ok(list);
    }

    internal static async Task<Results<NotFound, BadRequest, Ok<Product>>> GetById(string id, IProductService productsService)
    {
        if (!id.IdValidObjectId()) return TypedResults.BadRequest();
        var item = await productsService.GetAsync(id);
        if (item is null) return TypedResults.NotFound();
        return TypedResults.Ok(item);
    }

    internal static async Task CreateAsync(Product newProduct, IProductService productsService) =>
        await productsService.CreateAsync(newProduct);

    internal static async Task UpdateAsync(string id, Product updatedProduct, IProductService productsService) =>
          await productsService.UpdateAsync(id, updatedProduct);

    internal static async Task RemoveAsync(string id, IProductService productsService) =>
              await productsService.RemoveAsync(id);

}