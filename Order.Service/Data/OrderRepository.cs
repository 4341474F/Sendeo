using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Order.Service.Domain;
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

        public async Task<List<OrdersDto>> GetAllOrders()
        {
            return await _orderContext.Orders.ToListAsync();

        }

        public async Task<OrdersDto> FindById(string id)
        {
            return await _orderContext.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<OrdersDto> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<EntityEntry<OrdersDto>> Add(OrdersDto order)
        {
            return await _orderContext.Orders.AddAsync(order);
        }

        public Task<List<OrdersDto>> Update()
        {
            throw new NotImplementedException();
        }
        
    }
}
