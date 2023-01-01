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
                    Id = "1",
                    CustomerId = "1",
                    ProductId = "1",
                    OrderDate = new DateTime(),
                    //Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                },
                new Order()
                {
                    Id = "2",
                    CustomerId = "2",
                    ProductId = "1",
                    OrderDate = new DateTime(),
                    //Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                },
                new Order()
                {
                    Id = "3",
                    CustomerId = "3",
                    ProductId = "2",
                    OrderDate = new DateTime(),
                    //Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
                },
                new Order()
                {
                    Id = "4",
                    OrderDate = new DateTime(),
                    CustomerId = "4",
                    ProductId = "3",
                    //Products = new List<Product>() {new() {Name = "Product", Id = "2"}}
                },
                new Order()
                {
                    Id = "5",
                    OrderDate = new DateTime(),
                    CustomerId = "5",
                    ProductId = "4",
                    //Products = new List<Product>() {new() {Name = "Product", Id = "3"}}
                },

            };
            context.Orders.AddRangeAsync(orders);
            context.SaveChangesAsync();
        }
        
    }
}
