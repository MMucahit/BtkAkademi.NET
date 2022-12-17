using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        public IActionResult Register()
        {
            return View("Register");
        }
    }
}
