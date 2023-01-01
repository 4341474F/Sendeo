using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using CustomerService.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using OrderService.Domain;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using ProductService.Domain;

namespace CustomerService.Data
{
    public class CustomerApiContext : DbContext
    {
        public CustomerApiContext (DbContextOptions<CustomerApiContext> options)
            : base(options)
        {
            
        }

        public Microsoft.EntityFrameworkCore.DbSet<Customer>? Customer => Set<Customer>();
        public Microsoft.EntityFrameworkCore.DbSet<Order> Orders => Set<Order>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
        }
    }

    
}
