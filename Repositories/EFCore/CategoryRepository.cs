using Entities.Models;
using Entities.RequestParameters;
using Repositories.Abstracts;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public List<Category> Search(CategoryRequestParameters search)
        {
            return _context.Set<Category>().Where(c => c.Name.Contains(search.SearchTerm)).ToList();
        }

    }
}
