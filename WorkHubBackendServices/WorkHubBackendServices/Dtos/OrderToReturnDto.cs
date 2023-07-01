using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Dtos
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }

        public string EmployeeEmail { get; set; }

        public DateTime OrderDate { get; set; } 

        public DateTime OrderedForDate { get; set; }    

        public string OrderType { get; set; }

        public IReadOnlyList<OrderItemDto> OrderItems { get; set; }

        public string OrderStatus { get; set; }
    }
}
