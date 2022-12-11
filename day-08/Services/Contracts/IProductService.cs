using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProductsWithDetail();
        IEnumerable<Product> GetAllProducts();
        Product GetOneProductById(int id);
        IEnumerable<Product> GetAllProducts(ProductRequestParameters p);
        IEnumerable<Product> GetAllProductsByCategoryId(int id);
        Product Create(ProductForInsertionDto productDto);
        Product Update(ProductForUpdateDto productDto);
        Product Delete(int id);
        ProductForUpdateDto ProductToDto(Product product);
    }
}
