using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProdcutApiContext _productContext;
        public ProductRepository(ProdcutApiContext dbContext)
        {
            _productContext = dbContext ?? throw new ArgumentNullException(nameof(_productContext));

        }

        public async Task<Product> AddAsync(Product order)
        {
            await _productContext.Product.AddAsync(order);
            await _productContext.SaveChangesAsync();
            return order;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productContext.Product.ToListAsync();

        }

        public async Task<Product> FindById(string id)
        {
            return await _productContext.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> DeleteAsync(string Id)
        {
            var request = await _productContext.Product.FirstOrDefaultAsync(p => p.Id == Id);
            if (request?.Id == "")
                return($"Order with {Id} is not found!");

            _productContext.Product.Remove(request);
            await _productContext.SaveChangesAsync();
            return request.Id;
        }
        
    }
}
