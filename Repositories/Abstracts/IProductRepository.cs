using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Abstracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        List<Product> Search(ProductRequestParameters p);
        List<Product> CategoryDetail(int id);
    }
}
