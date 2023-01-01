using OrderService.Domain;

namespace CustomerService.Domain
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        

        public List<OrderDto> Orders { get; set; }
    }
}
