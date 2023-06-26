using System.ComponentModel.DataAnnotations;

namespace WorkHubBackEndServices.Dtos
{
    public class EmployeeDetailsDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RoleName { get; set; }

        public string Department { get; set; }

    }
}
