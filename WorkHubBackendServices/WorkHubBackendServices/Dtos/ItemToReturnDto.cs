using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Dtos
{
    public class ItemToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }

        public string Category { get; set; }
    }
}
