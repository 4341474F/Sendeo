namespace ProductService.Domain
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product Order);
        Task<List<Product>> GetAllProducts();
        Task<Product> FindById(string id);
        Task<string> DeleteAsync(string id);
    }
}
