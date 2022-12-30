using MediatR;
using CustomerService.Domain;

namespace CustomerService.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public Customer Customer { get; set; }
    }
}
