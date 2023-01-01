using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProductService.Domain;

namespace OrderService.Domain
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<Product> Products { get; set; }
        
    }
}
