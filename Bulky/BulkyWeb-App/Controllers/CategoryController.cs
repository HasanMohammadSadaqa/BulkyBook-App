using BulkyWeb_App.Data;
using BulkyWeb_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        //dependancy injection (constructor take an object as parameter >>>>> where the dependencies of a class are provided from the outside rather than created within the class itself)
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        //Action method to retrieve all categories 
        public IActionResult Index()
        {
            List<Category> objListCategories = _context.Categories.ToList();
            return View(objListCategories);
        }



        //Action methods to create new Category (2 action method with same name)

        //the first method is to display the view (the form)
        public IActionResult Create()
        {
            return View();
        }

        //the second method to create the new category object and save it to database

        [HttpPost]   //When you decorate a controller action method with [HttpPost], you're specifying that this method should only be invoked in response to an HTTP POST request.This means that it will handle form submissions, where data is sent to the server using the POST method, typically to perform create or update operations, among other things.

        public IActionResult Create(Category category)
        {
            //    if (category.Name == category.DisplayOrder.ToString())
            //    {
            //        ModelState.AddModelError("", "Category name and display order cannot match");
            //    }

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index", "Category");          // here we redirect to the list of category >>>>> the first qutation is name of view, and the second one is the name of controller
            }
            return View();
           
        }
    }
}
