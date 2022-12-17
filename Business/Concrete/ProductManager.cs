using AutoMapper;
using Business.Abstracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Abstracts;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Dependency Injection
        private readonly IRepositoryManager _productManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        //

        public Product Add(ProductForInsertionDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productManager.Product.Add(product);
            _productManager.Save();
            return product;
        }

        public List<Product> CategoryDetail(int id)
        {
            return _productManager.Product.CategoryDetail(id);
        }

        public Product Delete(int id)
        {
            var deletedProduct = _productManager.Product.GetById(p => p.Id == id);
            _productManager.Product.Delete(deletedProduct);
            _productManager.Save();
            return deletedProduct;
        }

        public List<Product> GetAll()
        {
            return _productManager.Product.GetAll();
        }

        public List<Product> GetAllProductsWithDetail()
        {
            return _productManager.Product.GeAllProductWithDetail();
        }

        public Product GetById(int id)
        {
            return _productManager.Product.GetById(p => p.Id == id);
        }

        public ProductForUpdateDto ProductToDto(Product product)
        {
            return _mapper.Map<ProductForUpdateDto>(product);
        }

        public List<Product> Search(ProductRequestParameters p)
        {
            return _productManager.Product.Search(p);
        }

        public Product Update(ProductForUpdateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productManager.Product.Update(product);
            _productManager.Save();
            return product;
        }
    }
}
