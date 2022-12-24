using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderService.Domain;

namespace OrderService.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderApiContext _orderContext;
        public OrderRepository(OrderApiContext dbContext)
        {
            _orderContext = dbContext ?? throw new ArgumentNullException(nameof(_orderContext));
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

        public Task<Order> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> Update()
        {
            throw new NotImplementedException();
        }
        
    }
}
