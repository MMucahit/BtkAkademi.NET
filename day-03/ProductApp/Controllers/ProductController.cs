using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;
using System.Linq;

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
            return View("GetOneProduct",product);
        }

        [HttpGet]
        public IActionResult CreateOneProduct()
        {
            return View("CreateOneProduct");
        }

        [HttpPost]
        public IActionResult CreateOneProduct(Product product) 
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}