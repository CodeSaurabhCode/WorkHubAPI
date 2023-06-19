using System.ComponentModel.DataAnnotations;

namespace WorkHubBackEndServices.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

    }
}
