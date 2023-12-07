using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Bulky.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 


        public IActionResult Index()
        {
            List<Product> objListOfproducts = _unitOfWork.Product.GetAll().ToList();
            return View(objListOfproducts);
        }



        public IActionResult Create()
        {
            ProductVM productVM = new ProductVM()
            {
                product = new Product(),
                categoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
            };

            //ViewBag.CategoryList = CategoryList;
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.AddOneElement(productVM.product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                productVM.categoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
            
            
        }

        public IActionResult Edit(int? ProductIdToEdit)
        {
            if (ProductIdToEdit == null || ProductIdToEdit == 0)
            {
                return NotFound($"Product with Id = {ProductIdToEdit} not found");
            }

            Product? ProductFromDbToEdit = _unitOfWork.Product.GetOneElement(u=>u.Id == ProductIdToEdit);
            if(ProductFromDbToEdit == null)
            {
                return NotFound($"Product with Id = {ProductIdToEdit} not found");
            }
            return View(ProductFromDbToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Product productToEdit)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Product.Update(productToEdit);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        public IActionResult Delete(int? productIdToDelete)
        {
            if (productIdToDelete == null || productIdToDelete == 0)
            {
                return NotFound($"Product with Id = {productIdToDelete} not found");
            }

            Product? ProductFromDbToDelete = _unitOfWork.Product.GetOneElement(u => u.Id == productIdToDelete);
            if (ProductFromDbToDelete == null)
            {
                return NotFound($"Product with Id = {productIdToDelete} not found");
            }
            return View(ProductFromDbToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Product productToDelete)
        {
                _unitOfWork.Product.RemoveOneElement(productToDelete);
                _unitOfWork.Save();
                TempData["success"] = "Product Deleted successfully";
                return RedirectToAction("Index", "Product");
        }
    }
}
