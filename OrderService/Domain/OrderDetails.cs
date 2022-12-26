using System.ComponentModel.DataAnnotations.Schema;
using ProductService.Domain;

namespace OrderService.Domain
{
    public class OrderDetails
    {
        public string Id { get; set; }
        public string OrderNo { get; set; }
        public string ProductId { get; set; }

        [ForeignKey("OrderNo")]
        public Order Order { get; set; } 
        [ForeignKey("ProductId")]
        public Product Products { get; set; }

    }
}
