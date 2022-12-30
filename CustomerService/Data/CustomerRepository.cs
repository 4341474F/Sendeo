using Microsoft.EntityFrameworkCore;
using CustomerService.Domain;

namespace CustomerService.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerApiContext _customerContext;
        public CustomerRepository(CustomerApiContext dbContext)
        {
            _customerContext = dbContext ?? throw new ArgumentNullException(nameof(_customerContext));
            _customerContext.Database.EnsureCreatedAsync();
            DbInitializers.Initialize(_customerContext);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _customerContext.Customer.AddAsync(customer);
            await _customerContext.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllOrders()
        {
            return await _customerContext.Customer.ToListAsync();

        }

        public async Task<Customer> FindById(string id)
        {
            return await _customerContext.Customer.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> DeleteAsync(string id)
        {
            var request = await _customerContext.Customer.FirstOrDefaultAsync(p => p.Id == id);
            if (request?.Id == "")
                return($"Order with {id} is not found!");

            _customerContext.Customer.Remove(request);
            await _customerContext.SaveChangesAsync();
            return request.Id;
        }
        
    }
}
