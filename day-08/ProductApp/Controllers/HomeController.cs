using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {

        string msg = "Dünya erkek günü kutlu olsun.";
        return View("Index", msg);
    }

    public IActionResult Privacy()
    {
        return View();
    }




}
