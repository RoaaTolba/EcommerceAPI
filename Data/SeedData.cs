using ecommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ecommerceAPI.Data
{
    public static class SeedData
    {
        public static async Task intialize(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            string[] roles = new string[] { "Admin", "Customer" };
            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            //create default user
            var adminEmail = "admin@ecommerce.com";
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var adminUser = new User { UserName=adminEmail,
                    Email = adminEmail ,
                    Name= "System Admin",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(adminUser, "Admin");
            }

        }
    }
}
