using MediatR;

namespace OrderService.Commands
{
    public class DeleteOrderCommand : IRequest<string>
    {
        public DeleteOrderCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
