namespace BasicEcommerce.Infrastructure.Context;
public class BasicEcommerceDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public BasicEcommerceDbContext()
    {
        
    }
    public BasicEcommerceDbContext(DbContextOptions<BasicEcommerceDbContext> options) : base(options) { }
}
