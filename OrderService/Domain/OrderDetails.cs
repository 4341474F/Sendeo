using System.ComponentModel.DataAnnotations.Schema;
using ProductAPI.Entities;

namespace OrderService.API.Domain
{
    public class OrderDetails
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string PorductId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("PorductId")]
        public Product Product { get; set; }

    }
}
