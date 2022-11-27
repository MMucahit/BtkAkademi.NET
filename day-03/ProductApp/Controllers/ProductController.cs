using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Controllers
{
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
            var products = _context.Products.ToList();
            return View("Index", products);
        }

        public IActionResult RandomProduct()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, _context.Products.ToList().Count + 1);
            var product = _context.Products.SingleOrDefault(p => p.Id == randomNumber);

            return product != null ? View("RandomProduct", product) : RandomProduct();
        }

        public IActionResult GetOneProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View("GetOneProduct", product);
        }

        [HttpGet]
        public IActionResult CreateOneProduct()
        {
            return View("CreateOneProduct");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOneProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("CreateOneProduct");

        }

        [HttpPost]
        public IActionResult DeleteOneProduct(int id)
        {
            Product deletedProduct = _context.Products.SingleOrDefault(p => p.Id == id);
            _context.Remove(deletedProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateOneProduct(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View("UpdateOneProduct", product);
        }

        [HttpPost]
        public IActionResult UpdateOneProduct(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("UpdateOneProduct");
        }
    }
}