namespace BasicEcommerce.Application.Interfaces;

public interface IProductService
{
    Task AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProduct(Guid Id);
}
