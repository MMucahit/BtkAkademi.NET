using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync
                        (user, loginDto.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Product");
                    }

                    else
                    {
                        ModelState.AddModelError("Error", "Email or Password is invalid!");
                    }
                }
            }
            return View("Login");
        }

        [HttpPost]
        // Asenkron method çalışması için Task ile sarmalanmalı ve Task olduğunda async de eklenmeli.
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                var appUser = new ApplicationUser()
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                };

                var result = await _userManager.CreateAsync(appUser, registerDto.Password);
                //_userManager.AddToRoleAsync(appUser, "User");
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }

            return View("Register");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
    }
}
