using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Entities;

namespace OrderAPI.Data
{
    public class OrderAPIContext : DbContext
    {
        public OrderAPIContext (DbContextOptions<OrderAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Order> Orders { get; set; } = default!;
        
    }
}
