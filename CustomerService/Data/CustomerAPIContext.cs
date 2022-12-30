using Microsoft.EntityFrameworkCore;
using CustomerService.Domain;
using OrderService.Domain;

namespace CustomerService.Data
{
    public class CustomerApiContext : DbContext
    {
        public CustomerApiContext (DbContextOptions<CustomerApiContext> options)
            : base(options)
        {
        }

        public DbSet<Customer>? Customer => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();

    }
}
