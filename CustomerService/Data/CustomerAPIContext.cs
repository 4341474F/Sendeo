using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using CustomerService.Domain;
using Microsoft.EntityFrameworkCore.Internal;
using OrderService.Domain;
using OrderService.Queries;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using ProductService.Domain;

namespace CustomerService.Data
{
    public class CustomerApiContext : DbContext
    {
        public CustomerApiContext(DbContextOptions<CustomerApiContext> options)
            : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Customer>? Customer => Set<Customer>();
        public Microsoft.EntityFrameworkCore.DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = "1",
                    OrderId = "1",
                    Name = "John",
                    LastName = "Doe",
                    Phone = "1234567",
                    Email = "cust1@sendeo.com",
                    Address = "Address1",
                },
                new Customer
                {
                    Id = "2",
                    OrderId = "2",
                    Name = "Lebron",
                    LastName = "James",
                    Phone = "1234567",
                    Email = "lebron@sendeo.com",
                    Address = "Address1",
                },
                new Customer
                {
                    Id = "3",
                    OrderId = "3",
                    Name = "Çağatay",
                    LastName = "ÇELİK",
                    Phone = "1234567",
                    Email = "cagatay@sendeo.com",
                    Address = "Address1",
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = "1",
                    CustomerId = "1",
                    OrderDate = new DateTime(),
                    
                },
                new Order
                {
                    Id = "2",
                    CustomerId = "2",
                    OrderDate = new DateTime(),
                    
                },
                new Order
                {
                    Id = "3",
                    CustomerId = "3",
                    OrderDate = new DateTime(),
                   
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "1",
                    OrderId = "1",
                    Name = "Product1",
                    Category = "Category1",
                    Description = "Desc1",
                    ImageFile = "null",
                    Price = 10,
                    Stock = 2
                },
                new Product
                {
                    Id = "2",
                    OrderId = "2",
                    Name = "Product2",
                    Category = "Category1",
                    Description = "Desc2",
                    ImageFile = "null",
                    Price = 20,
                    Stock = 1
                },
                new Product
                {
                    Id = "3",
                    OrderId = "3",
                    Name = "Product3",
                    Category = "Category2",
                    Description = "Desc3",
                    ImageFile = "null",
                    Price = 100,
                    Stock = 2
                }
            );
        }
    }


}
