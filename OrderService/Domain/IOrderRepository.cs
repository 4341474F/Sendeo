using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderService.Data;

namespace OrderService.Domain
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order Order);
        Task<List<Order>> GetAllOrders();
        Task<Order> FindById(string id);
        Task<Order> Delete(string id);
    }
}
