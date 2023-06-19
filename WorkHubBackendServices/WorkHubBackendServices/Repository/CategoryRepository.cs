using Microsoft.EntityFrameworkCore;
using WorkHubBackEndServices.Data;
using WorkHubBackEndServices.Interfaces;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IReadOnlyList<Category>> GetCategoreiesAsync()
        {
            var catogories = await _db.Categories.ToListAsync();
            return catogories;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _db.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _db.Items
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IReadOnlyList<Item>> GetItemsAsync()
        {
            return await _db.Items
                .Include(P => P.Category)
                .ToListAsync();
        }
    }
}
