using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ServiceManager(IProductService productService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _categoryService;
    }
}
