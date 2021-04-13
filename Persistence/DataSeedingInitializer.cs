using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DataSeedingInitializer
    {
        public static async Task UserSeedAsync(UserManager<IdentityUser> userManager)
        {

            if (userManager.FindByEmailAsync("jose@example.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "jose@example.com",
                    Email = "jose@example.com",
                };
                _ = userManager.CreateAsync(user, "p@ssw0rD").Result;

            }

            if (userManager.FindByEmailAsync("emerson@example.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "emerson@example.com",
                    Email = "emerson@example.com"
                };
                _ = userManager.CreateAsync(user, "p@ssw0rD").Result;

            }


            if (userManager.FindByEmailAsync("adilson@example.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "adilson@gmail.com",
                    Email = "adilson@gmail.com"
                };
                _ = userManager.CreateAsync(user, "p@ssw0rD").Result;

            }
        }
    }
}