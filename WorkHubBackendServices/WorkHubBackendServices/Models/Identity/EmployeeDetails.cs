using System.ComponentModel.DataAnnotations;

namespace WorkHubBackEndServices.Models.Identity
{
    public class EmployeeDetails
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RoleName { get; set; }

        public string Department { get; set; }

        [Required]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}