namespace BasicEcommerce.Infrastructure.Data;
public class InitialData
{
    public static IEnumerable<Product> Products =>
    new List<Product>
    {
           new Product{ Id= new Guid("f3044186-3bba-40ef-8ce5-8a1a7ef10302"), Name="Samsung Galaxy S24 Ultra", Price=69000, StockQuantity=5},
            new Product{ Id= new Guid("a4f99ded-2d2a-4c90-8070-d26b1951e969"), Name="Samsung Galaxy S23 Ultra", Price=35000, StockQuantity=5},
            new Product{ Id= new Guid("3a98b611-6b73-4c5f-b84e-cca787a6dab8"), Name="Apple iPhone 15 Plus (512 GB)", Price=76000, StockQuantity=5},
            new Product{ Id= new Guid("f1a382f3-a182-4f1c-8580-bf400c4dd4a0"), Name="Xioami Redmi Note 13", Price=11000, StockQuantity=3}
       };
}

