using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Interfaces
{
    public class OrdersCountSpecifications : BaseSpecifications<Order>
    {
        public OrdersCountSpecifications(string email)
            : base(o => o.EmployeeEmail == email)
        {

        }
    }
}
