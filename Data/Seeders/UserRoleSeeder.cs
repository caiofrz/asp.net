using Microsoft.AspNetCore.Identity;

namespace asp.net_mvc.Data.Seeders
{
    public class UserRoleSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRoleSeeder(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void SeedRoles()
        {

            string[] roles = ["Admin", "User",];

            foreach (var role in roles)
            {
                if (_roleManager.RoleExistsAsync(role).Result)
                {
                    return;
                }

                var newRole = new IdentityRole
                {
                    Name = role,
                    NormalizedName = role.ToUpper()
                };

                var roleResult = _roleManager.CreateAsync(newRole).Result;
            }
        }
        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "usuario@localhost",
                    Email = "usuario@localhost.com",
                    NormalizedUserName = "USUARIO@LOCALHOST",
                    NormalizedEmail = "USUARIO@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "#Teste1").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST",
                    NormalizedEmail = "ADMIN@LOCALHOST",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "#Admin123").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}