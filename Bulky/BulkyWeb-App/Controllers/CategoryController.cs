
using Bulky.DataAccess.Data;
using Bulky.Models.Models;
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
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");          // here we redirect to the list of category >>>>> the first qutation is name of view, and the second one is the name of controller
            }
            return View();
           
        }


        //Action Methods to Edit a specific Category: 

        public IActionResult Edit(int? categoryIdToEdit)
        {
            if (categoryIdToEdit == null || categoryIdToEdit == 0)
            {
                return NotFound();
            }

            Category? categoryFromDbToEdit = _context.Categories.Find(categoryIdToEdit);                                  /* Here there is multiple ways to get record from db, first way is "Find()" in this method it take Primery key for the model as default and it's true for our case,
            Category categoryFromDb2 = _context.Categories.FirstOrDefault(u => u.Id == categoryIdToEdit);             the second way is 'FirstOrDefault(link operation), in this case we will use link operation to find the element and it will work even the parameter(id) is not primery key,
            Category categoryFromDb3 = _context.Categories.Where(u => u.Id == categoryIdToEdit).FirstOrDefault();     the third way is where conition and it is as same as 'FirstOrDefault' way, it use link operation*/

            if (categoryFromDbToEdit == null)
            {
                return NotFound();
            }
            return View(categoryFromDbToEdit);
        }


        [HttpPost]

        public IActionResult Edit(Category categoryToEdit)
        {
            //    if (category.Name == category.DisplayOrder.ToString())
            //    {
            //        ModelState.AddModelError("", "Category name and display order cannot match");
            //    }

            if (ModelState.IsValid)
            {
                _context.Categories.Update(categoryToEdit);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");          
            }
            return View();

        }


        // Method to delete a record from Db
        public IActionResult Delete(int? categoryIdToDelete)
        {
            if(categoryIdToDelete == null || categoryIdToDelete == 0)
            {
                return NotFound($"Category with Id = {categoryIdToDelete} not found");
            }
            Category? categoryFromDbToDelete = _context.Categories.FirstOrDefault(u=> u.Id == categoryIdToDelete);

            if (categoryFromDbToDelete == null)
            {
                return NotFound($"Employee with Id = {categoryIdToDelete} not found");
            }
            return View(categoryFromDbToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Category categoryToDelete)
        {
            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category");
        }

    }
}
