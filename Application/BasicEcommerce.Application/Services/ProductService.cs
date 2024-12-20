
namespace BasicEcommerce.Application.Services;
public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepository.AddProductAsync(product);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllProductsAsync();
    }

    public async Task<Product> GetProduct(Guid Id)
    {
        return await _productRepository.GetProductByIdAsync(Id);
    }
}
