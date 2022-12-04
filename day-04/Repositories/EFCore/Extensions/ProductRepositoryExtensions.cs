using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilterProducts
            (this IQueryable<Product> products, uint minPrice, uint maxPrice)
        {
            return products.Where(p => p.Price < maxPrice && p.Price > minPrice);
        }
    }
}
