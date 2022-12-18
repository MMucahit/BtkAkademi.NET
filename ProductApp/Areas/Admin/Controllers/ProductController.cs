using AutoMapper;
using Business.Abstracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin,Editor")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        // Dependency Injection
        private readonly IServiceManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IServiceManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;

        }
        //

        public IActionResult Index()
        {
            var result = _productManager.ProductService.GetAllProductsWithDetail();
            //var result = _productManager.ProductService.GetAll();

            TempData["list"] = "Products have been listed!";

            return View("Index", result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(_productManager.CategoryService.GetAll().ToList(), "CategoryId", "Name");
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(ProductForInsertionDto productDto)
        {
            if (ModelState.IsValid)
            {
                _productManager.ProductService.Add(productDto);

                TempData["add"] = "Product has been added!";

                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productManager.ProductService.Delete(id);
            TempData["delete"] = "Product has been deleted!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Categories = new SelectList(_productManager.CategoryService.GetAll(), "CategoryId", "Name");
            Product product = _productManager.ProductService.GetById(id);
            return View("Update", product);
        }

        [HttpPost]
        public IActionResult Update(ProductForUpdateDto updatedProduct)
        {

            if (ModelState.IsValid)
            {
                _productManager.ProductService.Update(updatedProduct);

                TempData["update"] = "Products have been updated!";

                return RedirectToAction("Index");
            }
            return View("Update");
        }
    }
}