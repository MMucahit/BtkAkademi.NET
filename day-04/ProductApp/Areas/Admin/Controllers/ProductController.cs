using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.EFCore;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // Dependency Injection
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public ProductController(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(ProductForInsertionDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

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
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "Name");
            Product product = _context.Products.SingleOrDefault(p => p.Id == id);
            return View("Update", product);
        }

        [HttpPost]
        public IActionResult Update(ProductForUpdateDto updatedProduct)
        {
            var product = _mapper.Map<Product>(updatedProduct);

            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();

                TempData["update"] = "Products have been updated!";

                return RedirectToAction("Index");
            }
            return View("Update");
        }
    }
}