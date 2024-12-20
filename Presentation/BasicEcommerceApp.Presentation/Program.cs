using BasicEcommerce.Application.Services;
using BasicEcommerce.Domain.Interfaces;
using BasicEcommerce.Infrastructure.Context;
using BasicEcommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Read API Base URL from appsettings.json
var configuration = builder.Configuration;

// MS SQL Bağlantısı
var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BasicEcommerceDbContext>(options => options.UseSqlServer(connectionString));

// Servis ve Repository Bağımlılıklarını Ekliyoruz
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


var apiBaseUrl = configuration["ApiSettings:BaseUrl"]; // appsettings.json'dan oku

builder.Services.AddHttpClient("BasicEcommerceAPI", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl ?? string.Empty); // API'nizin çalıştığı adres ve port
});

// MVC'yi ekleyin
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Varsayılan Route'u ayarlayın
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
