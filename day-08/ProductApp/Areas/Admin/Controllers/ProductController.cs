using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Contracts;
using Services.Contracts;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var products = _manager.ProductService.GetAllProductsWithDetail();
            //var products = _manager.ProductService.GetAllProducts();

            TempData["info"] = "Products have been listed.";
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateOneProduct()
        {
            var categories = _manager.CategoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOneProduct(ProductForInsertionDto productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.Create(productDto);

                TempData["success"] = "Product has been created";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateOneProduct(int id)
        {
            ViewBag.Categories =
                new SelectList(_manager.CategoryService.GetAllCategories(),
                "CategoryId", "CategoryName");

            var product = _manager.ProductService.GetOneProductById(id);
            var productTo = _manager.ProductService.ProductToDto(product);
            return View(productTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOneProduct(ProductForUpdateDto productDto)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.Update(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteOneProduct(int id)
        {
            _manager.ProductService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
