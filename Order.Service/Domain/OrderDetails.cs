using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ProductAPI.Entities;


namespace OrderAPI.Entities
{
    public class OrderDetails
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string PorductId { get; set; }

        [ForeignKey("OrderId")]
        public Order.Service.Domain.Order Order { get; set; }
        [ForeignKey("PorductId")]
        public Product Product { get; set; }

    }
}
