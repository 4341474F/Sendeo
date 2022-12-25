using System.ComponentModel.DataAnnotations.Schema;
using ProductService.Domain;

namespace OrderService.Domain
{
    public class OrderDetails
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string PorductId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } 
        [ForeignKey("PorductId")]
        public Product Products { get; set; }

    }
}
