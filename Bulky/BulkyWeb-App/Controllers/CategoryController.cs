using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_App.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
