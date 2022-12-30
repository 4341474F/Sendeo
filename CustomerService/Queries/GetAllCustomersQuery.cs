using MediatR;
using CustomerService.Domain;

namespace CustomerService.Queries
{

    public class GetAllCustomersQuery :IRequest<List<CustomerDto>>
    {
        
    }
}
