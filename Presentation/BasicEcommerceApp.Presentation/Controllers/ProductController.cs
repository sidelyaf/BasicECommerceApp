using BasicEcommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BasicEcommerceApp.Presentation.Controllers;
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient client;
    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        client = _httpClientFactory.CreateClient("BasicEcommerceAPI");
    }

    public async Task<IActionResult> Index()
    {
        var products = await client.GetFromJsonAsync<IEnumerable<Product>>("/api/products");
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid)
        {
            var response = await client.PostAsJsonAsync("/api/products", product);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> ProductDetail(Guid productId)
    {
        if (ModelState.IsValid)
        {
            Product response = await client.GetFromJsonAsync<Product>($"/api/products/getproduct/{productId}") ?? new Product();

            return View(response);
        }
        return View();
    }
}
