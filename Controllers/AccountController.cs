using AnimalPlaceProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalPlaceProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);
               if(result.Succeeded)
                {
                    ViewBag.User = model;
                    return RedirectToAction("Index", "Home", model);
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");   
        }
        public async Task<IActionResult> Register()
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = "User123",
            };

            var result = await _userManager.CreateAsync(user, "123qwe!@#QWE");

            if(result.Succeeded)
            {
                return Content("Ok");
            }
            else
            {
                var errorMessage = string.Join(", ", result.Errors.Select(error => error.Description));
                return Content($"Failed: {errorMessage}");
            }
        }
    }
} 
