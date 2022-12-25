﻿using System.ComponentModel.DataAnnotations;

namespace OrderService.Domain
{
    public class Order
    {
        public string Id { get; set; }
        public string OrderNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}
