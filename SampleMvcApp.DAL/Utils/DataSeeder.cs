using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SampleMvcApp.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SampleMvcApp.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace SampleMvcApp.DAL.Utils
{
    public class DataSeeder
    {
        private DbContext Context { get; set; }

        public DataSeeder(DbContext context)
        {
            Context = context;
        }

        public async Task Seed(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, string defaultAdminPw)
        {
            await SeedInitialAdmin(userManager, roleManager, defaultAdminPw);
        }

        private async Task SeedInitialAdmin(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager, string defaultAdminPw)
        {
            var username = "admin";
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new AppRole { Name = "admin" });
            }

            if (await userManager.FindByNameAsync(username) == null)
            {
                var user = new AppUser { UserName = username };
                var userSuccess = await userManager.CreateAsync(user, defaultAdminPw);

                if (userSuccess == IdentityResult.Success)
                {
                    await userManager.AddToRoleAsync(user, username);
                }
            }
        }
    }
}
