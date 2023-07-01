using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorkHubBackEndServices.Models;
using WorkHubBackEndServices.Models.OrderModels;

namespace WorkHubBackEndServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<OrderItem> orderitems { get; set; }

        public DbSet<OrderType> OrderTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Veg" },
                new Category() { Id = 2, Name = "Non-Veg" }
                );

            modelBuilder.Entity<OrderType>().HasData(
                new OrderType() { Id = 1, TypeName = "Breakfast" },
                new OrderType() { Id = 2, TypeName = "Lunch" }
                );

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Veggie Burger",
                    Description = "Delicious vegetarian burger with fresh vegetables and sauce",
                    Price = 120,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Paneer Tikka",
                    Description = "Marinated cottage cheese cubes grilled with spices",
                    Price = 180,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 3,
                    Name = "Masala Dosa",
                    Description = "Thin crispy crepe made from fermented rice and lentil batter, served with chutney and sambar",
                    Price = 100,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 4,
                    Name = "Chicken Biryani",
                    Description = "Flavorful rice dish cooked with chicken, aromatic spices, and herbs",
                    Price = 200,
                    CategoryId = 2
                },
                new Item
                {
                    Id = 5,
                    Name = "Gulab Jamun",
                    Description = "Soft and spongy milk-based dessert soaked in sugar syrup",
                    Price = 80,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 6,
                    Name = "Palak Paneer",
                    Description = "Creamy spinach curry with paneer (cottage cheese)",
                    Price = 160,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 7,
                    Name = "Butter Chicken",
                    Description = "Tender chicken pieces cooked in a rich and creamy tomato-based sauce",
                    Price = 220,
                    CategoryId = 2
                },
                new Item
                {
                    Id = 8,
                    Name = "Samosa",
                    Description = "Crispy fried pastry filled with spiced potatoes and peas",
                    Price = 60,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 9,
                    Name = "Chicken Tikka Masala",
                    Description = "Grilled chicken in a creamy and flavorful tomato-based sauce",
                    Price = 190,
                    CategoryId = 2
                },
                new Item
                {
                    Id = 10,
                    Name = "Rasmalai",
                    Description = "Soft and creamy cheese dumplings in sweetened milk",
                    Price = 90,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 11,
                    Name = "Chole Bhature",
                    Description = "Spicy chickpea curry served with deep-fried bread",
                    Price = 140,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 12,
                    Name = "Fish Curry",
                    Description = "Fish cooked in a tangy and flavorful curry",
                    Price = 180,
                    CategoryId = 2
                },
                new Item
                {
                    Id = 13,
                    Name = "Aloo Paratha",
                    Description = "Indian bread stuffed with spiced mashed potatoes, served with yogurt or pickle",
                    Price = 80,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 14,
                    Name = "Mutton Biryani",
                    Description = "Fragrant rice dish cooked with tender mutton pieces, aromatic spices, and herbs",
                    Price = 240,
                    CategoryId = 2
                },
                new Item
                {
                    Id = 15,
                    Name = "Gajar Halwa",
                    Description = "Traditional Indian dessert made with grated carrots, milk, and sugar",
                    Price = 100,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 16,
                    Name = "Pani Puri",
                    Description = "Small crispy puris filled with spicy tangy water and potato mixture",
                    Price = 70,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 17,
                    Name = "Matar Paneer",
                    Description = "Peas and paneer (cottage cheese) cooked in a creamy and flavorful sauce",
                    Price = 160,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 18,
                    Name = "Chicken 65",
                    Description = "Spicy and flavorful deep-fried chicken dish",
                    Price = 180,
                    CategoryId = 2
                },
                new Item
                {
                    Id = 19,
                    Name = "Rajma Chawal",
                    Description = "Red kidney bean curry served with steamed rice",
                    Price = 120,
                    CategoryId = 1
                },
                new Item
                {
                    Id = 20,
                    Name = "Dal Makhani",
                    Description = "Creamy and rich lentil curry made with black lentils and kidney beans",
                    Price = 140,
                    CategoryId = 1
                }
            );


            //modelBuilder.Entity<MenuItemOrdered>()
            //    .HasNoKey();

            modelBuilder.Entity<OrderItem>()
                .OwnsOne(i => i.ItemOrdered, io => { io.WithOwner(); }) ;
          

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
