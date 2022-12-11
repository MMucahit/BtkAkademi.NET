using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetOneCategoryById(int id);
        Category Create(Category category);
        Category Update(Category category);
        Category Delete(int id);
    }
}
