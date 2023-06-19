using System.ComponentModel.DataAnnotations;

namespace WorkHubBackEndServices.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
