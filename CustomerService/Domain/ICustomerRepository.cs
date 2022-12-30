namespace CustomerService.Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> AddAsync(Customer customer);
        Task<List<Customer>> GetAllOrders();
        Task<Customer> FindById(string id);
        Task<string> DeleteAsync(string id);
    }
}
