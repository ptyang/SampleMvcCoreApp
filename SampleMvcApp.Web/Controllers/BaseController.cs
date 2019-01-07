using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.DAL.Identity;

namespace SampleMvcApp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<AppUser> UserManager { get; set; }

        protected SignInManager<AppUser> SignInManager { get; set; }

        public BaseController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
    }
}