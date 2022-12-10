using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Abstracts;
using Repositories.EFCore;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // Dependency Injection
        private readonly IRepositoryManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IRepositoryManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;

        }
        //

        public IActionResult Index()
        {
            var result = _productManager.Product.GetAll();

            TempData["list"] = "Products have been listed!";

            return View("Index", result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(_productManager.Category.GetAll().ToList(), "CategoryId", "Name");
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(ProductForInsertionDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if (ModelState.IsValid)
            {
                _productManager.Product.Add(product);
                _productManager.Save();

                TempData["add"] = "Product has been added!";

                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Product deletedProduct = _productManager.Product.GetById(p => p.Id == id);
            _productManager.Product.Delete(deletedProduct);
            _productManager.Save();

            TempData["delete"] = "Product has been deleted!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Categories = new SelectList(_productManager.Category.GetAll(), "CategoryId", "Name");
            Product product = _productManager.Product.GetById(p => p.Id == id);
            return View("Update", product);
        }

        [HttpPost]
        public IActionResult Update(ProductForUpdateDto updatedProduct)
        {
            var product = _mapper.Map<Product>(updatedProduct);

            if (ModelState.IsValid)
            {
                _productManager.Product.Update(product);
                _productManager.Save();

                TempData["update"] = "Products have been updated!";

                return RedirectToAction("Index");
            }
            return View("Update");
        }
    }
}