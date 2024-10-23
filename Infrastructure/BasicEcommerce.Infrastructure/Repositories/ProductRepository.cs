namespace BasicEcommerce.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly BasicEcommerceDbContext _context;

    public ProductRepository(BasicEcommerceDbContext context)
    {
        _context = context;
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        if (id != Guid.Empty || _context is null || _context.Products is null) return new Product();
        return await _context.Products.FindAsync(id);
    }
}

