namespace WorkHubBackEndServices.Models.OrderModels
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems,string employeeEmail, 
            DateTime orderedForDate, OrderType orderType)
        {
            EmployeeEmail = employeeEmail;
            OrderedForDate = orderedForDate;
            OrderType = orderType;
            OrderItems = orderItems;
        }

        public string EmployeeEmail { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public DateTime OrderedForDate { get; set; }

        public OrderType OrderType { get; set; }

        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public OrderStatus OrderStatus { get; set; }


    }
}
