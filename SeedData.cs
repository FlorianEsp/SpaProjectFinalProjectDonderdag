using Microsoft.AspNetCore.Identity;
using SpaProjectFinalProject.Models;

namespace SpaProjectFinalProject
{
    public static class SeedData
    {
        public static void Seed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin1@gmail.com",
                    Email = "Admin1@gmail.com"
                };
                var result = userManager.CreateAsync(user, "Admin1@gmail.com").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole { Name = "User" };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
