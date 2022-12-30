using Microsoft.EntityFrameworkCore;
using OrderService.Domain;

namespace OrderService.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderApiContext _orderContext;
        public OrderRepository(OrderApiContext dbContext)
        {
            _orderContext = dbContext ?? throw new ArgumentNullException(nameof(_orderContext));
            _orderContext.Database.EnsureCreatedAsync();
            DbInitializers.Initialize(_orderContext);
        }

        public async Task<Order> AddAsync(Order order)
        {
            await _orderContext.Orders.AddAsync(order);
            await _orderContext.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderContext.Orders.ToListAsync();

        }

        public async Task<Order> FindById(string id)
        {
            return await _orderContext.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> DeleteAsync(string Id)
        {
            var request = await _orderContext.Orders.FirstOrDefaultAsync(p => p.Id == Id);
            if (request?.Id == "")
                return($"Order with {Id} is not found!");

            _orderContext.Orders.Remove(request);
            await _orderContext.SaveChangesAsync();
            return request.Id;
        }
        
    }
}
