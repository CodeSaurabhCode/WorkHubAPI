using System.Text.Json;
using WorkHubBackEndServices.Models;

namespace WorkHubBackEndServices.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var CategoryData = File.ReadAllText("./Data/SeedData/CategoryData.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(CategoryData);
                context.Categories.AddRange(categories);
            }

            if (!context.Items.Any())
            {
                var ItemsData = File.ReadAllText("./Data/SeedData/MenuItems.json");
                var items = JsonSerializer.Deserialize<List<Item>>(ItemsData);
                context.Items.AddRange(items);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

        }
    }
}
