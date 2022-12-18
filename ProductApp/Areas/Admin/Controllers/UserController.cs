using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _userManager.Users.ToListAsync();
            //var query = from user in _userManager.Users
            //            join role in _roleManager.Roles
            //            on user.Id equals role.Id
            //            select (new DtoLazım
            //            {
            //                FirstName = user.FirstName,
            //                LastName = user.LastName,
            //                Email = user.Email,
            //                UserName = user.UserName,
            //                Role = role.Name
            //            });
            return View("Index", results);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = await _userManager.FindByNameAsync(id);
            var roles = await _roleManager.Roles.ToListAsync();
            ViewBag.Roles = roles;
            ViewBag.RolesList = new SelectList(roles, "Id", "Name");
            return View("AddRole",user);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string UserName,string role)
        {
            var _role = await _roleManager.FindByIdAsync(role);
            var _user = await _userManager.FindByNameAsync(UserName);
            
            var rst = await _userManager.AddToRoleAsync(_user, _role.Name);
            if (rst.Succeeded)
            {
                return RedirectToAction("Index");
            }

            else
            {
                foreach (var err in rst.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string UserName, string role)
        {
            var _role = await _roleManager.FindByIdAsync(role);
            var _user = await _userManager.FindByNameAsync(UserName);

            var rst = await _userManager.RemoveFromRoleAsync(_user, _role.Name);
            
            if (rst.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var err in rst.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return RedirectToAction("Index");
        }
    }
}