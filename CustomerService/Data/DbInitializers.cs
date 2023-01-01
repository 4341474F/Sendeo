using CustomerService.Domain;
using ProductService.Domain;

namespace CustomerService.Data
{
    public static class DbInitializers
    {
        public static void Initialize(CustomerApiContext context)
        {
            if (context.Customer.Any())
                return;
            
            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Id = "1",
                    Address = "Adress.1",
                    Email = "user1@sendeo.com",
                    Name = "User 1 Name",
                    LastName = "User 1 LastName",
                    Phone = "1234567",
                },
                new Customer()
                {
                    Id = "Order.2",
                    Address = "Adress.2",
                    Email = "user1@sendeo.com",
                    Name = "User 2 Name",
                    LastName = "User 2 LastName",
                    Phone = "1234567",
                    
                },
                new Customer()
                {
                    Id = "Order.3",
                    Address = "Adress.3",
                    Email = "user1@sendeo.com",
                    Name = "User 3 Name",
                    LastName = "User 3 LastName",
                    Phone = "1234567",
                },
                new Customer()
                {
                    Id = "Order.4",
                    Address = "Adress.4",
                    Email = "user1@sendeo.com",
                    Name = "User 4 Name",
                    LastName = "User 4 LastName",
                    Phone = "1234567",
                    
                },
                new Customer()
                {
                    Id = "Order.5",
                    Address = "Adress.5",
                    Email = "user1@sendeo.com",
                    Name = "User 5 Name",
                    LastName = "User 5 LastName",
                    Phone = "1234567",
                },

            };
            context.Customer.AddRangeAsync(customers);
            context.SaveChangesAsync();
        }
        
    }
}
