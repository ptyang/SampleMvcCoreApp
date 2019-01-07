using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.DAL.Identity;
using SampleMvcApp.Web.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SampleMvcApp.Web.Controllers
{
    public class AccountController : BaseController
    {

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var vm = new LoginViewModel();
            return View("Login", vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                model.ErrorMessage = "Invalid credentials were supplied.";
                return View("Login", model);
            }
            var user = await UserManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                model.ErrorMessage = "Invalid credentials were supplied.";
                return View("Login", model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
            if (!result.Succeeded)
            {
                model.ErrorMessage = "Invalid credentials were supplied.";
                return View("Login", model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}