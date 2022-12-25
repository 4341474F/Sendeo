namespace ProductService.Domain
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product Order);
        Task<List<Product>> GetAllOrders();
        Task<Product> FindById(string id);
        Task<string> DeleteAsync(string id);
    }
}
