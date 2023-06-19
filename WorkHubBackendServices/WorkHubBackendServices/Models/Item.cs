using System.ComponentModel.DataAnnotations;

namespace WorkHubBackEndServices.Models
{
    public class Item 
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
