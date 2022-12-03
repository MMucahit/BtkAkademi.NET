using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // Dependency Injection
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }
        //

        public IActionResult Index()
        {
            var result = _context.Products.ToList();

            TempData["list"] = "Products have been listed!";

            return View("Index", result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();

                TempData["add"] = "Product has been added!";

                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product deletedProduct = _context.Products.SingleOrDefault(p => p.Id == id);
            _context.Remove(deletedProduct);
            _context.SaveChanges();

            TempData["delete"] = "Product has been deleted!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View("Update", product);
        }

        [HttpPost]
        public IActionResult Update(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedProduct);
                _context.SaveChanges();

                TempData["update"] = "Products have been updated!";

                return RedirectToAction("Index");
            }
            return View("Update");
        }
    }
}