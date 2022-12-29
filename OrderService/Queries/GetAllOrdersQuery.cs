using MediatR;
using OrderService.Domain;

namespace OrderService.Queries
{

    public class GetAllOrdersQuery :IRequest<List<OrderDto>>
    {
        
    }
}
