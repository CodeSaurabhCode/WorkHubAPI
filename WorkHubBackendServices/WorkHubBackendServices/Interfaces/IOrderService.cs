using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string employeeEmail, DateTime orderedFordate, int orderTypeId, string basketId );

        Task<IReadOnlyList<Order>> GetOrdersForEmployeeAsync(string employeeEmail, OrderSpecParams pageParams);
        Task<Order> GetOrderByIdAsync(int id, string employeeEmail);

        Task<IReadOnlyList<OrderType>> GetOrderTypesAsync();

        Task<OrderType> GetOrderTypeByIdAsync(int id);


    }
}
