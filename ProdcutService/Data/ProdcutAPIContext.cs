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
                new Product() { Id = Guid.NewGuid().ToString(), Category = "Category1", Description = "Description1", ImageFile = "ImageFile1", Name = "Name1", Price = 100 },
                new Product() { Id = Guid.NewGuid().ToString(), Category = "Category2", Description = "Description2", ImageFile = "ImageFile1", Name = "Name1", Price = 100 },
                new Product() { Id = Guid.NewGuid().ToString(), Category = "Category1", Description = "Description3", ImageFile = "ImageFile1", Name = "Name1", Price = 200 },
                new Product() { Id = Guid.NewGuid().ToString(), Category = "Category2", Description = "Description4", ImageFile = "ImageFile1", Name = "Name1", Price = 10 },
                new Product() { Id = Guid.NewGuid().ToString(), Category = "Category3", Description = "Description5", ImageFile = "ImageFile1", Name = "Name1", Price = 250 }
            );
        }
    }
}
