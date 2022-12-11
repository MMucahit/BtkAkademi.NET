using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ProductApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _categoryService;

        public CategoryController(IServiceManager categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.CategoryService.GetAllCategories();
            return View(categories);
        }
    }
}
