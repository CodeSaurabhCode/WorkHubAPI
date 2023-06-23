using Microsoft.AspNetCore.Identity;
using System.Net;

namespace WorkHubBackEndServices.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
    }
}
