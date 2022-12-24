using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OrderService.Domain
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order Order);
        Task<List<Order>> GetAllOrders();
        Task<Order> FindById(string id);
        Task<string> DeleteAsync(string id);
    }
}
