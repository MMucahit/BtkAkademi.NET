using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Abstracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        List<Category> Search(CategoryRequestParameters c);
    }
}
