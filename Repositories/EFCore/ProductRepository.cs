using Entities.Models;
using Entities.RequestParameters;
using Repositories.Abstracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public List<Product> Search(ProductRequestParameters search)
        {
            //return _context.Set<Product>().Where(p => p.Price > search.MinPrice && p.Price < search.MaxPrice).ToList();
            return _context.Set<Product>()
                .FilterProducts(search.MinPrice, search.MaxPrice)
                //.Where(p => p.Name.Contains(search.SearchTerm))
                .Search(search.SearchTerm)
                .ToList();
        }

        public List<Product> SearchTerm(string term)
        {
            return GetAll(p => p.Name.Contains(term)).ToList();
            //return _context.Set<Product>().Where(c => c.Name.Contains(term)).ToList();
        }

        public List<Product> CategoryDetail(int id)
        {
            return GetAll(p => p.CategoryId == id).ToList();
            //return _context.Set<Product>().Where(p => p.CategoryId == id).ToList();
        }
    }
}
