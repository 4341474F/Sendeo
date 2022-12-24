using Microsoft.EntityFrameworkCore;

namespace OrderService.Data
{
    public class OrderApiContext : DbContext
    {
        public OrderApiContext (DbContextOptions<OrderApiContext> options)
            : base(options)
        {
        }

        public DbSet<OrdersDto> Orders { get; set; } = default!;
        
    }
}
