using AuthApp.Constants;
using AuthApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthApp.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                // Create roles if they do not exist
                foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
                {
                    if (!await roleManager.RoleExistsAsync(role.ToString()))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role.ToString()));
                    }
                }

                // Create users if they do not exist and assign roles
                await CreateUserIfNotExists(userManager, "admin-email-example-1@mail.com", "admin-1", "Admin-password-example-1!", UserRoles.Admin);
                await CreateUserIfNotExists(userManager, "user-email-example-1@mail.com", "user-1", "User-password-example-1!", UserRoles.Client);
                await CreateUserIfNotExists(userManager, "prestataire-email-example-1@mail.com", "prestataire-1", "Prestataire-password-example-1!", UserRoles.Prestataire);
            }
        }

        private static async Task CreateUserIfNotExists(UserManager<AppUser> userManager, string email, string userName, string password, UserRoles role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new AppUser { UserName = userName, Email = email };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, role.ToString());
            }
        }
    }
}
