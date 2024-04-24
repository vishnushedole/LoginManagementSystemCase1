using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetUsers()
        {
            return View();
        }
    }
}
