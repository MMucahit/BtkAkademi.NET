using Business.Abstracts;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Abstracts;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        // Dependency Injection
        private readonly IRepositoryManager _categoryManager;

        public CategoryManager(IRepositoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        //

        public void Add(Category category)
        {
            _categoryManager.Category.Add(category);
            _categoryManager.Save();
        }

        public void Delete(int id)
        {
            var deletedCategory = _categoryManager.Category.GetById(c => c.CategoryId == id);
            _categoryManager.Category.Delete(deletedCategory);
            _categoryManager.Save();
        }

        public List<Category> GetAll()
        {
            return _categoryManager.Category.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryManager.Category.GetById(c => c.CategoryId == id);
        }

        public List<Product> GetProductsById(int id)
        {
            return _categoryManager.Product.GetAll(c => c.CategoryId == id);
        }

        public List<Category> Search(CategoryRequestParameters c)
        {
            return _categoryManager.Category.Search(c);
        }

        public void Update(Category category)
        {
            _categoryManager.Category.Update(category);
            _categoryManager.Save();
        }
    }
}
