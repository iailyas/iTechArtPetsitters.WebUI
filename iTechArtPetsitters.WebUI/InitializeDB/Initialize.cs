using Domain.Models;
using Domain.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.InitializeDB
{
    public static class Initialize
    {
        public static void AddRoles(RoleManager<IdentityRole> roleManager) 
        {
            if (roleManager.FindByNameAsync("Administrator").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "Administrator".ToUpper()
                };
                var result = roleManager.CreateAsync(adminRole).Result;
            }

            if (roleManager.FindByNameAsync("User").Result == null)
            {
                var userRole = new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                };
                var result = roleManager.CreateAsync(userRole).Result;
            }
            if (roleManager.FindByNameAsync("Petsitter").Result == null)
            {
                var userRole = new IdentityRole
                {
                    Name = "Petsitter",
                    NormalizedName = "Petsitter".ToUpper()
                };
                var result = roleManager.CreateAsync(userRole).Result;
            }
        }
        public static void AddAdmin(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "administrator@admin.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin"
                };

                var result = userManager.CreateAsync(user,"String123-111").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user,"Administrator").Result;
                }
           
            }

        }

    }
}
