using BasicEcommerce.Domain.Interfaces;
using BasicEcommerce.Infrastructure.Context;
using BasicEcommerce.Infrastructure.Repositories;
using BasicEcommerce.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MS SQL Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BasicEcommerceDbContext>(options => options.UseSqlServer(connectionString));

// Register Services and Repositories
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Veritabanını oluştur ve güncelle
    await app.InitialiseDatabaseAsync();
}

app.MapControllers();
app.Run();



