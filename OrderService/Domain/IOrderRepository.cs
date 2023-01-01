namespace OrderService.Domain
{
    public interface IOrderRepository
    {
        Task<Order> AddAsync(Order Order);
        Task<List<Order>> GetAllOrders();
        Task<Order> FindById(string id);
        Task<Order> FindByDate(DateTime date);
        Task<string> DeleteAsync(string id);
    }
}
