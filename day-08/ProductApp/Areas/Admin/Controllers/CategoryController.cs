using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var categories = _manager.CategoryService.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateOneCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOneCategory(Category category)
        {
            if (category is null)
                throw new Exception();

            if (ModelState.IsValid)
            {
                _manager.CategoryService.Create(category);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateOneCategory(int id)
        {
            var category = _manager.CategoryService.GetOneCategoryById(id);
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOneCategory(Category category)
        {
            if (category is null)
                throw new Exception();

            if (ModelState.IsValid)
            {
                _manager.CategoryService.Update(category);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteOneCategory(int id)
        {
            _manager.CategoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
