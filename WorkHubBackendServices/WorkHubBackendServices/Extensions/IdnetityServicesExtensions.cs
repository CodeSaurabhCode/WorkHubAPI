using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Models.Identity;

namespace WorkHubBackEndServices.Extensions
{
    public static class IdnetityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, 
            IConfiguration config) 
        {
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("IdentityConnection"));
            });

            services.AddIdentityCore<AppUser>(opt =>
            {

            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }

    }
}
