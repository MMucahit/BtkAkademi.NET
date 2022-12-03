using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        // Dependency Injection
        private readonly RepositoryContext _context;

        public CategoryController(RepositoryContext context)
        {
            _context = context;
        }
        //

        public IActionResult Index()
        {
            var result = _context.Categories.ToList();
            return View("Index", result);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View("AddCategory");
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddCategory");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var deletedCategory = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            _context.Remove(deletedCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            return View("UpdateCategory", category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category updatedCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(updatedCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("UpdateCategory");
        }
    }
}
