﻿using System.ComponentModel.DataAnnotations;
using ProductService.Domain;

namespace OrderService.Domain
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        
        public DateTime OrderDate { get; set; }
        public virtual List<Product> Products { get; set; }
        
    }
}
