using Business.Abstracts;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        //// Dependency Injection
        //private readonly IProductRepository _productDal;

        //public ProductController(IProductRepository productDal)
        //{
        //    _productDal = productDal;
        //}
        ////

        //// Dependency Injection
        //private readonly IRepositoryManager _productManager;

        //public ProductController(IRepositoryManager productManager)
        //{
        //    _productManager = productManager;
        //}
        ////

        //// Dependency Injection
        //public readonly IProductService _productService;

        //public ProductController(IProductService productService)
        //{
        //    _productService = productService;
        //}
        ////

        // Dependency Injection
        public readonly IServiceManager _productService;

        public ProductController(IServiceManager productService)
        {
            _productService = productService;
        }
        //

        public IActionResult Index()
        {
            var products = _productService.ProductService.GetAll();
            //var products = _productService.GetAll();
            //var products = _productManager.Product.GetAll();
            //var products = _productDal.GetAll();
            return View("Index", products);
        }

        public IActionResult GetOneProduct(int id)
        {
            var product = _productService.ProductService.GetById(id);
            //var product = _productService.GetById(id);
            //var product = _productManager.Product.GetById(p => p.Id == id);
            //var product = _productDal.GetById(p => p.Id == id);
            return View("GetOneProduct", product);
        }

        [HttpPost]
        public IActionResult Search(ProductRequestParameters search)
        {
            var products = _productService.ProductService.Search(search);
            //var products = _productService.Search(search);
            //var products = _productManager.Product.Search(search);
            //var products = _productDal.Search(search);
            return View("Search", products);
        }

        public IActionResult CategoryDetail(int id)
        {
            var categories = _productService.ProductService.CategoryDetail(id);
            //var categories = _productService.CategoryDetail(id);
            //var categories = _productManager.Product.CategoryDetail(id);
            //var categories = _productDal.CategoryDetail(id);
            return View("CategoryDetail", categories);
        }
    }
}