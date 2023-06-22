namespace WorkHubBackEndServices.Models
{
    public class EmployeeBasket
    {
        public EmployeeBasket()
        {
        }

        public EmployeeBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
