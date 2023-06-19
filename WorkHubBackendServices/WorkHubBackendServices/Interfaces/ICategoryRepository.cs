using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Item> GetItemByIdAsync(int id);

        Task<IReadOnlyList<Category>> GetCategoreiesAsync();
        Task<IReadOnlyList<Item>> GetItemsAsync();


    }
}
