namespace WorkHubBackEndServices.Models.OrderModels
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(MenuItemOrdered itemOrdered)
        {
            ItemOrdered = itemOrdered;
            
        }

        public MenuItemOrdered ItemOrdered { get; set; }
       
    }
}
