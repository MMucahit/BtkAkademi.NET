using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstracts;
using Repositories.EFCore;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        // Dependency Injection
        private readonly IProductRepository _productDal;

        public ProductController(IProductRepository productDal)
        {
            _productDal = productDal;
        }
        //

        public IActionResult Index()
        {
            var products = _productDal.GetAll();
            return View("Index", products);
        }

        public IActionResult GetOneProduct(int id)
        {
            var product = _productDal.GetById(id);
            return View("GetOneProduct", product);
        }

        [HttpPost]
        public IActionResult Search(ProductRequestParameters search)
        {
            var product = _productDal.Search(search);
            return View("Search",product);
        }
    }
}