using MediatR;

namespace OrderService.API.Commands
{
    public class UpdateOrderCommand : IRequest
    {
       public string Id { get; set; }

    }
}
