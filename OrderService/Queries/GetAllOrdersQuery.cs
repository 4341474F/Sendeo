using MediatR;
using OrderService.API.Data;

namespace OrderService.API.Queries
{

    public class GetAllOrdersQuery :IRequest<List<OrdersDto>>
    {
        
    }
}
