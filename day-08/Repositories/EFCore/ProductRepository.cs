using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context)
            : base(context)
        {
        }

        public IEnumerable<Product> GeAllProductWithDetail()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public IEnumerable<Product> GetAllProducts() =>
             FindAll();

        public IEnumerable<Product> GetAllProducts(ProductRequestParameters p)
        {
            return _context
                 .Products
                 .FilterProducts(p.MinPrice, p.MaxPrice)
                 .Search(p.SearchTerm)
                 .ToList();
        }

        public IEnumerable<Product> GetAllProductsByCategoryId(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId.Equals(categoryId))
                .ToList();
        }

        public Product GetOneProductById(int id)
        {
            return _context
                .Products
                .Where(p => p.Id.Equals(id))
            .SingleOrDefault();
        }


    }
}
