﻿using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            var products = _manager.ProductService.GetAllProducts(p);
            return View("Index", products);
        }

        public IActionResult GetOneProduct(int id)
        {
            var product = _manager.ProductService.GetOneProductById(id);
            return View("GetOneProduct", product);
        }

        public IActionResult GetAllProductsByCategoryId(int id)
        {
            var products = _manager
                .ProductService.GetAllProductsByCategoryId(id);

            return View("Index", products);
        }
    }
}
