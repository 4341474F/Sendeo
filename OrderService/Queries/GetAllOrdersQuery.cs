using MediatR;
using OrderService.Data;
using OrderService.Domain;

namespace OrderService.Queries
{

    public class GetAllOrdersQuery :IRequest<List<Order>>
    {
        
    }
}
