using CustomerService.Domain;
using OrderService.Domain;
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
                    Orders = new List<Order>() { new() { CustomerId = "1", Id = "1", OrderDate = new DateTime(),  Products = new List<Product>
                        {
                            new ()
                            {
                                Id = "1",
                                Name = "Product1",
                                Price = 10,
                                Stock = 2
                            }
                        }
                    } }
                },
                new Customer()
                {
                    Id = "2",
                    Address = "Adress.2",
                    Email = "user1@sendeo.com",
                    Name = "User 2 Name",
                    LastName = "User 2 LastName",
                    Phone = "1234567",
                    Orders = new List<Order>() { new() {CustomerId = "2", Id = "2", OrderDate = new DateTime(), Products = new List<Product>
                        {
                            new ()
                            {
                                Id = "2",
                                Name = "Product1",
                                Price = 10,
                                Stock = 2
                            }
                        }
                    } }
                },
                new Customer()
                {
                    Id = "3",
                    Address = "Adress.3",
                    Email = "user1@sendeo.com",
                    Name = "User 3 Name",
                    LastName = "User 3 LastName",
                    Phone = "1234567",
                    Orders = new List<Order>() { new() {CustomerId = "3", Id = "3", OrderDate = new DateTime(), Products = new List<Product>
                        {
                            new ()
                            {
                                Id = "2",
                                Name = "Product1",
                                Price = 10,
                                Stock = 2
                            }
                        }
                    } }
                },
                new Customer()
                {
                    Id = "4",
                    Address = "Adress.4",
                    Email = "user1@sendeo.com",
                    Name = "User 4 Name",
                    LastName = "User 4 LastName",
                    Phone = "1234567",
                    Orders = new List<Order>() { new() {CustomerId = "4", Id = "4", OrderDate = new DateTime(), Products = new List<Product>
                        {
                            new ()
                            {
                                Id = "3",
                                Name = "Product1",
                                Price = 10,
                                Stock = 2
                            }
                        }
                    } }

                },
                new Customer()
                {
                    Id = "5",
                    Address = "Adress.5",
                    Email = "user1@sendeo.com",
                    Name = "User 5 Name",
                    LastName = "User 5 LastName",
                    Phone = "1234567",
                    Orders = new List<Order>() { new() {CustomerId = "5", Id = "5", OrderDate = new DateTime(), Products = new List<Product>
                        {
                            new ()
                            {
                                Id = "3",
                                Name = "Product1",
                                Price = 10,
                                Stock = 2
                            }
                        }
                    } }
                },

            };
            context.Customer.AddRangeAsync(customers);
            context.SaveChangesAsync();
        }
        
    }
}
