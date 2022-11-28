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

    [HttpGet]
    public IActionResult CreateOneCategory()
    {
        return View("CreateOneCategory");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateOneCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("CreateOneCategory");

    }

    [HttpPost]
    public IActionResult DeleteOneCategory(int id)
    {
        Category deletedCategory = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
        _context.Remove(deletedCategory);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateOneCategory(int id)
    {
        Category category = _context.Categories.SingleOrDefault(p => p.CategoryId == id);
        return View("UpdateOneCategory", category);
    }

    [HttpPost]
    public IActionResult UpdateOneCategory(Category updatedCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Update(updatedCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("UpdateOneCategory");
    }

}

