using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstracts;

namespace ProductApp.Controllers;


public class CategoryController : Controller
{
    // Dependency Injection
    private readonly IRepositoryManager _categoryManager;

    public CategoryController(IRepositoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }
    //

    public IActionResult Index()
    {
        var category = _categoryManager.Category.GetAll();
        return View("Index", category);
    }

    public IActionResult GetOneCategory(int id)
    {
        var products = _categoryManager.Product.CategoryDetail(id);
        return View("GetOneCategory", products);
    }

    [HttpPost]
    public IActionResult Search(CategoryRequestParameters search)
    {
        var category = _categoryManager.Category.Search(search);
        return View("Search", category);
    }
}

