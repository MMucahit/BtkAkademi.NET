using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Abstracts
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> Search(ProductRequestParameters p);

    }
}
