using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstracts;

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

        // Dependency Injection
        private readonly IRepositoryManager _productManager;

        public ProductController(IRepositoryManager productManager)
        {
            _productManager = productManager;
        }
        //

        public IActionResult Index()
        {
            var products = _productManager.Product.GetAll();
            //var products = _productDal.GetAll();
            return View("Index", products);
        }

        public IActionResult GetOneProduct(int id)
        {
            var product = _productManager.Product.GetById(p => p.Id == id);
            //var product = _productDal.GetById(p => p.Id == id);
            return View("GetOneProduct", product);
        }

        [HttpPost]
        public IActionResult Search(ProductRequestParameters search)
        {
            var products = _productManager.Product.Search(search);
            //var products = _productDal.Search(search);
            return View("Search", products);
        }

        public IActionResult CategoryDetail(int id)
        {
            var categories = _productManager.Product.CategoryDetail(id);
            //var categories = _productDal.CategoryDetail(id);
            return View("CategoryDetail", categories);
        }
    }
}