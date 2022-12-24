using MediatR;

namespace OrderService.API.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public string Id { get; set; }
    }
}
