using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.Data
{
    public class ProdcutApiContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public ProdcutApiContext (DbContextOptions<ProdcutApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new()
                    {
                        Id = "1",
                        Name = "Product 1",
                        Category = "Category 1",
                        Description = "Desc 1",
                        ImageFile = null,
                        Price = 10,
                        Stock = 2
                    },
                    new()
                    {
                        Id = "2",
                        Name = "Product 2",
                        Category = "Category 2",
                        Description = "Desc 2",
                        ImageFile = null,
                        Price = 30,
                        Stock = 1
                    }
                }
            );
        }
    }
}
