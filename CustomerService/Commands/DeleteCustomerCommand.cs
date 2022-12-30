using MediatR;

namespace CustomerService.Commands
{
    public class DeleteCustomerCommand : IRequest<string>
    {
        public DeleteCustomerCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
