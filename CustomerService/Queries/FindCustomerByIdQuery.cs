using MediatR;
using CustomerService.Domain;

namespace CustomerService.Queries
{

    public class FindCustomerByIdQuery :IRequest<CustomerDto>
    {
        public string Id { get; }

        public FindCustomerByIdQuery(string id)
        {
            Id = id;
        }   
    }
}
