using Business.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace ProductApp.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        // Dependency Injection
        private readonly ICategoryService _categoryManager;

        public CategoryViewComponent(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }
        //

        public IViewComponentResult Invoke()
        {
            var categories = _categoryManager.GetAll();
            return View("Default", categories);
        }
    }
}
