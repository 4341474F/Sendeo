﻿
using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain
{
    public class Product
    {
        
        [Key]
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
