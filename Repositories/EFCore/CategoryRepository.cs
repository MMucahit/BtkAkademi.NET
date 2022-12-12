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

        public void Add(Category category)
        {
            _context.Set<Category>().Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletedProduct = _context.Set<Category>().SingleOrDefault(p => p.CategoryId == id);
            _context.Set<Category>().Remove(deletedProduct);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Set<Category>().ToList();
        }

        public List<Product> GetById(int id)
        {
            return _context.Set<Product>().Where(p => p.CategoryId == id).ToList();
        }

        public List<Category> Search(CategoryRequestParameters search)
        {
            return _context.Set<Category>().Where(c => c.Name.Contains(search.SearchTerm)).ToList();
        }

        public void Update(Category category)
        {
            _context.Set<Category>().Update(category);
            _context.SaveChanges();
        }
    }
}
