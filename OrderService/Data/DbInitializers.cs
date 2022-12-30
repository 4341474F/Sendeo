using OrderService.Domain;
using ProductService.Domain;

namespace OrderService.Data
{
    public static class DbInitializers
    {
        public static void Initialize(OrderApiContext context)
        {
            if (context.Orders.Any())
                return;
            
            var orders = new List<Order>()
            {
                new Order()
                {
                    Id = "Order.1",
                    Address = "Adress.1",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 1",
                    OrderDate = new DateTime(),
                    OrderNo = "1",
                    Phone = "1234567",
                    Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                },
                new Order()
                {
                    Id = "Order.2",
                    Address = "Adress.2",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 2",
                    OrderDate = new DateTime(),
                    OrderNo = "2",
                    Phone = "1234567",
                    Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                },
                new Order()
                {
                    Id = "Order.3",
                    Address = "Adress.3",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 3",
                    OrderDate = new DateTime(),
                    OrderNo = "3",
                    Phone = "1234567",
                    Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                },
                new Order()
                {
                    Id = "Order.4",
                    Address = "Adress.4",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 4",
                    OrderDate = new DateTime(),
                    OrderNo = "4",
                    Phone = "1234567",
                    Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                },
                new Order()
                {
                    Id = "Order.5",
                    Address = "Adress.5",
                    Email = "user1@sendeo.com",
                    Name = "Sendeo Order 5",
                    OrderDate = new DateTime(),
                    OrderNo = "5",
                    Phone = "1234567",
                    Products = new List<Product>() {new() {Name = "Product", Id = "3"}}
                },

            };
            context.Orders.AddRangeAsync(orders);
            context.SaveChangesAsync();
        }
        
    }
}
