namespace BasicEcommerce.WebAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        await _productService.AddProductAsync(product);
        return CreatedAtAction(nameof(GetAllProducts), new { id = product.Id }, product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet]
    [Route("getproduct/{id}")]
    public async Task<IActionResult> GetProduct(Guid Id)
    {
        var products = await _productService.GetProduct(Id);
        return Ok(products);
    }
}

