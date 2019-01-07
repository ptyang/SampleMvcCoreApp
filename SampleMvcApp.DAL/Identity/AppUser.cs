using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SampleMvcApp.DAL.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
        //    UserManager<AppUser> manager, string authenticationType)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
        //    return userIdentity;
        //}
    }
}
