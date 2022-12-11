using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ProductApp.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IServiceManager _categoryService;

        public CategoryViewComponent(IServiceManager categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.CategoryService.GetAllCategories();
            return View(categories);
        }
    }
}
