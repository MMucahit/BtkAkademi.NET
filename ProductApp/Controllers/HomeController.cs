using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {

        string msg = "Hello World!";
        return View("Index", msg);
    }

    public IActionResult Privacy()
    {
        return View();
    }




}
