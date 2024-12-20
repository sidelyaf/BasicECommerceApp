namespace BasicEcommerce.Infrastructure.Data;
public class InitialData
{
    public static IEnumerable<Product> Products =>
    new List<Product>
    {
           new Product{ Id= new Guid("f3044186-3bba-40ef-8ce5-8a1a7ef10302"), Name="Dürüm Et Döner", Price=350, StockQuantity=10, Description="En lezzetli yaprak et döner", ImageUrl="durum-et-doner_b.png" },
            new Product{ Id= new Guid("a4f99ded-2d2a-4c90-8070-d26b1951e969"), Name="Fırın Sütlaç", Price=150, StockQuantity=15, Description="Müthiş lezzetli fırın sütlaç, fındık ile servis edillir", ImageUrl="fırınsutlac.jpg"},
            new Product{ Id= new Guid("3a98b611-6b73-4c5f-b84e-cca787a6dab8"), Name="Eslem Et Burger", Price=300, StockQuantity=15, Description="Özel sosuyla et burger", ImageUrl="hamburger.png"},
            new Product{ Id= new Guid("f1a382f3-a182-4f1c-8580-bf400c4dd4a0"), Name="Zeytinyağlı Yaprak Sarma", Price=200, StockQuantity=5, Description="Ev yapımı hakiki zeytinyağlı yaprak sarma", ImageUrl="zeytinyagli_sarma.jpg"},
            new Product{ Id= new Guid("56483625-334d-453f-84ae-68fb7222019c"), Name="Sütlü çikolatalı Waffle", Price=11000, StockQuantity=3, Description="Kivi, muz ve çilekli Belçika çikolatalı waffle", ImageUrl="waffle.jpg"}
       };
}

