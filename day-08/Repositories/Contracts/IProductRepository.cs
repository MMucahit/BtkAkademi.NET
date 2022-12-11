using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetOneProductById(int id);
        IEnumerable<Product> GetAllProducts(ProductRequestParameters p);
        IEnumerable<Product> GetAllProductsByCategoryId(int id);
        IEnumerable<Product> GeAllProductWithDetail();
    }
}
