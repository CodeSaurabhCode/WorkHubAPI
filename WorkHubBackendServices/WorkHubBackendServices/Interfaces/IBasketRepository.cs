using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Interfaces
{
    public interface IBasketRepository
    {
        Task<EmployeeBasket> GetBasketAsync(string basketId);

        Task<EmployeeBasket> UpdateBasketAsync(EmployeeBasket basket);

        Task<bool> DeleteBasketAsync(string basketId);
    }
}
