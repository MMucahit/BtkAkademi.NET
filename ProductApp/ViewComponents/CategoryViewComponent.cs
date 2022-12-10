using Microsoft.AspNetCore.Mvc;
using Repositories.Abstracts;

namespace ProductApp.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        // Dependency Injection
        private readonly ICategoryRepository _categoryDal;

        public CategoryViewComponent(ICategoryRepository categoryDal)
        {
            _categoryDal = categoryDal;
        }
        //

        public IViewComponentResult Invoke()
        {
            var categories = _categoryDal.GetAll();
            return View("Default", categories);
        }
    }
}
