using System.Linq.Expressions;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Interfaces
{
    public class OrdersSpecifications : BaseSpecifications<Order>
    {
        public OrdersSpecifications(string email, OrderSpecParams pageParams) : base( o => o.EmployeeEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.OrderType);
            AddOrderByDescending(o => o.OrderedForDate);

            ApplyPaging(pageParams.PageSize * (pageParams.PageIndex - 1), pageParams.PageSize);
        }

        public OrdersSpecifications(int id, string email) 
            : base(o => o.Id == id && o.EmployeeEmail == email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.OrderType);
        }
    }
}
