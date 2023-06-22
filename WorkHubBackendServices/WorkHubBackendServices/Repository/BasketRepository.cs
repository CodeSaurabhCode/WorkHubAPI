using StackExchange.Redis;
using System.Text.Json;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<EmployeeBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<EmployeeBasket>(data);
        }

        public async Task<EmployeeBasket> UpdateBasketAsync(EmployeeBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, 
                JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));


            if (!created) return null;

            return await GetBasketAsync(basket.Id);


        }

        Task IBasketRepository.DeleteBasketAsync(string basketId)
        {
            throw new NotImplementedException();
        }
    }
}
