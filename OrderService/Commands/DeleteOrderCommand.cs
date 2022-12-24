using MediatR;

namespace OrderService.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public string Id { get; set; }
    }
}
