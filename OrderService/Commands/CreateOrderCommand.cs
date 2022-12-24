using MediatR;
using OrderService.Domain;

namespace OrderService.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
