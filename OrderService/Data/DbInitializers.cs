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
                    OrderDate = new DateTime(),
                    Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                },
                new Order()
                {
                    Id = "Order.2",
                    OrderDate = new DateTime(),
                    Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                },
                new Order()
                {
                    Id = "Order.3",
                    OrderDate = new DateTime(),
                    Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                },
                new Order()
                {
                    Id = "Order.4",
                    OrderDate = new DateTime(),
                    Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                },
                new Order()
                {
                    Id = "Order.5",
                    OrderDate = new DateTime(),
                    Products = new List<Product>() {new() {Name = "Product", Id = "3"}}
                },

            };
            context.Orders.AddRangeAsync(orders);
            context.SaveChangesAsync();
        }
        
    }
}
