using Business.Abstracts;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Controllers;


public class CategoryController : Controller
{
    // Dependency Injection
    private readonly IServiceManager _categoryManager;

    public CategoryController(IServiceManager categoryManager)
    {
        _categoryManager = categoryManager;
    }
    //

    public IActionResult Index()
    {
        var categories = _categoryManager.CategoryService.GetAll();
        return View("Index", categories);
    }

    public IActionResult GetOneCategory(int id)
    {
        var products = _categoryManager.ProductService.CategoryDetail(id);
        return View("GetOneCategory", products);
    }

    [HttpPost]
    public IActionResult Search(CategoryRequestParameters search)
    {
        var category = _categoryManager.CategoryService.Search(search);
        return View("Search", category);
    }
}

