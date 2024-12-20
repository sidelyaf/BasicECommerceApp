using Microsoft.AspNetCore.Mvc;

namespace BasicEcommerceApp.Presentation.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
