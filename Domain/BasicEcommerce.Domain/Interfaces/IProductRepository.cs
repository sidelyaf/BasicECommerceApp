using BasicEcommerce.Domain.Entities;

namespace BasicEcommerce.Domain.Interfaces;
public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task AddProductAsync(Product product);
}

