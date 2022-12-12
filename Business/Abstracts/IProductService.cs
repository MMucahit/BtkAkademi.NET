using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Abstracts;

namespace Business.Abstracts
{
    public interface IProductService
    {
        List<Product> Search(ProductRequestParameters p);
        List<Product> CategoryDetail(int id);
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(ProductForInsertionDto productDto);
        Product Update(ProductForUpdateDto productDto);
        Product Delete(int id);
        ProductForUpdateDto ProductToDto(Product product);
    }
}