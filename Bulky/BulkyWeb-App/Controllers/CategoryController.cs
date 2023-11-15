using BulkyWeb_App.Data;
using BulkyWeb_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> objListCategories = _context.Categories.ToList();
            return View(objListCategories);
        }
    }
}
