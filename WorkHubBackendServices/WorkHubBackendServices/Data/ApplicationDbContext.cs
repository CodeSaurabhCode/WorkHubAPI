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

            //modelBuilder.Entity<MenuItemOrdered>()
            //    .HasNoKey();

            modelBuilder.Entity<OrderItem>()
                .OwnsOne(i => i.ItemOrdered, io => { io.WithOwner(); }) ;
          

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
