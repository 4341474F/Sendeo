using Microsoft.EntityFrameworkCore;
using OrderService.Domain;
using ProductService.Domain;

namespace OrderService.Data
{
    public class OrderApiContext : DbContext
    {
        public OrderApiContext (DbContextOptions<OrderApiContext> options)
            : base(options)
        {
        }

        public DbSet<Order>? Orders => Set<Order>();
        public DbSet<Product>? Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new List<Order>()
                {
                    new()
                    {
                        Id = "1",
                        CustomerId = "1",
                        ProductId = "1",
                        OrderDate = new DateTime(),
                        //Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                    },
                    new()
                    {
                        Id = "2",
                        CustomerId = "2",
                        ProductId = "1",
                        OrderDate = new DateTime(),
                        //Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                    },
                    new()
                    {
                        Id = "3",
                        CustomerId = "3",
                        ProductId = "2",
                        OrderDate = new DateTime(),
                        //Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                    },
                    new()
                    {
                        Id = "4",
                        OrderDate = new DateTime(),
                        CustomerId = "4",
                        ProductId = "3",
                        //Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                    },
                    new()
                    {
                        Id = "5",
                        OrderDate = new DateTime(),
                        CustomerId = "5",
                        ProductId = "4",
                        //Products = new List<Product>() {new() {Name = "Product", Id = "3"}}
                    },

                });
        }
    }
}
