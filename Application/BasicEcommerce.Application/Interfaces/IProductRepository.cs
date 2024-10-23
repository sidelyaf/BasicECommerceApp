namespace BasicEcommerce.Application.Interfaces;
public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task AddProductAsync(Product product);
}

