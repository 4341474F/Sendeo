using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderService.Data;

namespace OrderService.Domain
{
    public interface IOrderRepository
    {
        Task<EntityEntry<OrdersDto>> Add(OrdersDto Order);

        Task<List<OrdersDto>> GetAllOrders();
        Task<OrdersDto> FindById(string id);

        Task<OrdersDto> Delete(string id);
    }
}
