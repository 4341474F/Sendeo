using MediatR;
using OrderService.Data;

namespace OrderService.Commands
{
    public class UpdateOrderCommand : IRequest
    {
        public string OrderId { get; set; }
       public OrdersDto Orders { get; set; }
    }
}
