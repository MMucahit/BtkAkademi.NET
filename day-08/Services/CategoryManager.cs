using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public Category Create(Category category)
        {
            _manager.Category.Create(category);
            _manager.Save();
            return category;
        }

        public Category Delete(int id)
        {
            var deletedCategory = GetOneCategoryById(id);
            _manager.Category.Delete(deletedCategory);
            _manager.Save();
            return deletedCategory;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _manager.Category.GetAllCategories();
        }

        public Category GetOneCategoryById(int id)
        {
            var category = _manager.Category.GetOneCategoryById(id);
            return category == null ? throw new Exception() : category;
        }

        public Category Update(Category category)
        {
            _manager.Category.Update(category);
            _manager.Save();
            return category;
        }
    }
}
