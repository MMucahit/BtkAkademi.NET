using Business.Abstracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin,Editor")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        // Dependency Injection
        private readonly IServiceManager _categoryManager;

        public CategoryController(IServiceManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        //

        public IActionResult Index()
        {
            var result = _categoryManager.CategoryService.GetAll();
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
                _categoryManager.CategoryService.Add(category);
                return RedirectToAction("Index");
            }
            return View("AddCategory");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            _categoryManager.CategoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryManager.CategoryService.GetById(id);
            return View("UpdateCategory", category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category updatedCategory)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.CategoryService.Update(updatedCategory);
                return RedirectToAction("Index");
            }
            return View("UpdateCategory");
        }
    }
}
