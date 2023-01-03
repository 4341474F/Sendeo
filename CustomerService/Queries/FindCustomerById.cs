using MediatR;
using CustomerService.Domain;

namespace CustomerService.Queries
{

    public class FindCustomerById :IRequest<List<CustomerDto>>
    {
        
    }
}
