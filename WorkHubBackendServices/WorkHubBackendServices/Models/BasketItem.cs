namespace WorkHubBackEndServices.Models
{
    public class BasketItem
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Category { get; set; }
    }
}
