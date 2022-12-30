using CustomerService.Domain;
using ProductService.Domain;

namespace CustomerService.Data
{
    public static class DbInitializers
    {
        public static void Initialize(CustomerApiContext context)
        {
            if (context.Orders.Any())
                return;
            
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Id = "Order.1",
                    Address = "Adress.1",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 1",
                    Phone = "1234567",
                },
                new Customer()
                {
                    Id = "Order.2",
                    Address = "Adress.2",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 2",
                    Phone = "1234567",
                    
                },
                new Customer()
                {
                    Id = "Order.3",
                    Address = "Adress.3",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 3",
                    Phone = "1234567",
                },
                new Customer()
                {
                    Id = "Order.4",
                    Address = "Adress.4",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 4",
                    Phone = "1234567",
                    
                },
                new Customer()
                {
                    Id = "Order.5",
                    Address = "Adress.5",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 5",
                    Phone = "1234567",
                },

            };
            context.Customer.AddRangeAsync(customers);
            context.SaveChangesAsync();
        }
        
    }
}
