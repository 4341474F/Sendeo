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

    }
}
