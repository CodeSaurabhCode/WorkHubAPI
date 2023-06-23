using Microsoft.AspNetCore.Identity;
using System.Net;
using WorkHubBackEndServices.Models.Identity;

namespace WorkHubBackEndServices.Data
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Saurabh",
                    Email = "saurabh.kshirsagar@kongsbergdigital.com",
                    UserName = "saurabh.kshirsagar@kongsbergdigital.com",
                    EmployeeDetails = new EmployeeDetails
                    {
                        FirstName = "Saurabh",
                        LastName = "Kshirsagar",
                        RoleName = "Development Engineer L3",
                        Department = "Digital Ocean"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
