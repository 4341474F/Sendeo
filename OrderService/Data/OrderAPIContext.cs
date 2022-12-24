using Microsoft.EntityFrameworkCore;
using OrderService.Domain;

namespace OrderService.Data
{
    public class OrderApiContext : DbContext
    {
        public OrderApiContext (DbContextOptions<OrderApiContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        
    }
}
