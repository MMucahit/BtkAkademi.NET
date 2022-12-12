using Entities.Models;
using Entities.RequestParameters;
using Repositories.Abstracts;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        List<Category> Search(CategoryRequestParameters c);
        List<Category> GetAll();
        List<Product> GetProductsById(int id);
        Category GetById(int id);
        void Delete(int id);
        void Add(Category category);
        void Update(Category category);
    }
}
