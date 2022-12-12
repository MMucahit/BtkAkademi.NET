using Entities.Models;

namespace Repositories.EFCore.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilterProducts
            (this IQueryable<Product> products, uint minPrice, uint maxPrice)
        {
            return products.Where(p => p.Price < maxPrice && p.Price > minPrice);
        }

        public static IQueryable<Product> Search(this IQueryable<Product> products, string term)
        {
            return term == null ? products : products.Where(p => p.Name.Contains(term));
        }
    }
}
