using Microsoft.AspNetCore.Mvc;

namespace WebSiteWasi.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
