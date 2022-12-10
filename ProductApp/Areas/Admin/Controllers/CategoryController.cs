using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstracts;
using Repositories.EFCore;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        // Dependency Injection
        private readonly IRepositoryManager _categoryManager;

        public CategoryController(IRepositoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        //

        public IActionResult Index()
        {
            var result = _categoryManager.Category.GetAll();
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
                _categoryManager.Category.Add(category);
                _categoryManager.Save();
                return RedirectToAction("Index");
            }
            return View("AddCategory");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var deletedCategory = _categoryManager.Category.GetById(c => c.CategoryId == id);
            _categoryManager.Category.Delete(deletedCategory);
            _categoryManager.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryManager.Category.GetById(c => c.CategoryId == id);
            return View("UpdateCategory", category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category updatedCategory)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.Category.Update(updatedCategory);
                _categoryManager.Save();
                return RedirectToAction("Index");
            }
            return View("UpdateCategory");
        }
    }
}
