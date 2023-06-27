using System.Linq.Expressions;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Interfaces
{
    public class OrdersSpecifications : BaseSpecifications<Order>
    {
        public OrdersSpecifications(string email) : base( o => o.EmployeeEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.OrderType);
            AddOrderByDescending(o => o.OrderedForDate);
        }

        public OrdersSpecifications(int id, string email) 
            : base(o => o.Id == id && o.EmployeeEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.OrderType);
        }
    }
}
