using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Repository
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Item> _item;
        private readonly IGenericRepository<OrderType> _orderType;
        private readonly IGenericRepository<Category> _category;
        private readonly IBasketRepository _basket;
        private readonly ApplicationDbContext _db;

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<Item> item, 
            IGenericRepository<OrderType> orderType, IGenericRepository<Category> category, IBasketRepository basket, ApplicationDbContext db)
        {
            _orderRepo = orderRepo;
            _item = item;
            _orderType = orderType;
            _category = category;
            _basket = basket;
            _db = db;
        }

        public async Task<Order> CreateOrderAsync(string employeeEmail, DateTime orderedFordate, int orderTypeId, string basketId)
        {
            var basket = await _basket.GetBasketAsync(basketId);

            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var menuItem = await _item.GetByIdAsync(item.Id);
                var category = await _category.GetByIdAsync(menuItem.CategoryId);
                var itemOrdered = new MenuItemOrdered(menuItem.Id, menuItem.Name, category.Name);
                var orderItem = new OrderItem(itemOrdered);
                items.Add(orderItem);
            }

            var orderType = await _orderType.GetByIdAsync(orderTypeId);

            var order = new Order(items, employeeEmail, orderedFordate, orderType);

            await _db.orders.AddAsync(order);
            
            await _db.SaveChangesAsync();

            await _basket.DeleteBasketAsync(basketId);

            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id, string employeeEmail)
        {
            var spec = new OrdersSpecifications(id, employeeEmail);

            return await _orderRepo.GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForEmployeeAsync(string employeeEmail, OrderSpecParams pageParams)
        {
            var spec = new OrdersSpecifications(employeeEmail, pageParams);

            return await _orderRepo.ListAsync(spec);
        }

        public async Task<IReadOnlyList<OrderType>> GetOrderTypesAsync()
        {
            return await _orderType.ListAllAsync();
        }
    }
}
