using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Controllers;


public class CategoryController : Controller
{
    // Dependency Injection
    private readonly RepositoryContext _context;

    public CategoryController(RepositoryContext context)
    {
        _context = context;
    }
    //

    public IActionResult Index()
    {
        List<Category> category = _context.Categories.ToList();
        return View("Index", category);
    }

    public IActionResult RandomCategory()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, _context.Categories.ToList().Count + 1);
        var category = _context.Categories.SingleOrDefault(p => p.CategoryId == randomNumber);

        return category != null ? View("RandomCategory", category) : RandomCategory();
    }


    public IActionResult GetOneCategory(int id)
    {
        var category = _context.Categories.SingleOrDefault(p => p.CategoryId == id);
        return View("GetOneCategory", category);
    }
}

