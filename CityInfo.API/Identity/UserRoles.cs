using Microsoft.AspNetCore.Identity;

namespace CityInfo.API.Identity
{
    public class UserRoles
    {
        public async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var roles = new List<string> { "Admin", "Patient", "Doctor_L1", "Doctor_Lm", "Doctor_Lx" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminUser = await userManager.FindByNameAsync("Loacladmin@cityInfo.com");
            if (adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

    }
}
