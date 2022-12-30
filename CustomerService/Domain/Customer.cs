using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using OrderService.Domain;
using ProductService.Domain;

namespace CustomerService.Domain
{
    public class Customer
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual List<Order> Orders { get; set; }

    }
}
