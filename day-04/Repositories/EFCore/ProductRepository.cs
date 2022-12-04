using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ProductRepository : IProductRepository
    {
        private readonly RepositoryContext _context;

        public ProductRepository(RepositoryContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product GetById(int id)
        {
            return _context.Set<Product>().SingleOrDefault(p => p.Id == id);
        }

        public List<Product> Search(ProductRequestParameters search)
        {
            //return _context.Set<Product>().Where(p => p.Price > search.MinPrice && p.Price < search.MaxPrice).ToList();
            return _context.Set<Product>().FilterProducts(search.MinPrice, search.MaxPrice).ToList();
        }

        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
