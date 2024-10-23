using BasicEcommerce.Domain.Entities;
using BasicEcommerceApp.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicEcommerceApp.Presentation.Controllers;
public class OrderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient client;

    public OrderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        client = _httpClientFactory.CreateClient("BasicEcommerceAPI");
    }

    public async Task<IActionResult> Index()
    {
        var orders = await client.GetFromJsonAsync<IEnumerable<Order>>("/api/orders");
        return View(orders);
    }

    public async Task<IActionResult> Create()
    {
        var products = await client.GetFromJsonAsync<IEnumerable<Product>>("/api/products");
        var model = new OrderViewModel { Products = products };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderViewModel model)
    {
        if (ModelState.IsValid)
        {
            var order = new Order
            {
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                CustomerName = model.CustomerName
            };

            var response = await client.PostAsJsonAsync("/api/orders", order);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // Eğer model geçerli değilse veya sipariş oluşturulamadıysa, ürünleri tekrar getir.
        if (client is null) return View(model);
        model.Products = await client?.GetFromJsonAsync<IEnumerable<Product>>("/api/products");

        return View(model);
    }
}

