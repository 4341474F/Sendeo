using MediatR;

namespace ProductService.Commands
{
    public class DeleteProductCommand : IRequest<string>
    {
        public DeleteProductCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
