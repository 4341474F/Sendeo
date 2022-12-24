using MediatR;
using OrderService.API.Data;
using OrderService.API.Domain;
using OrderService.API.Queries;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrdersDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<List<OrdersDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllOrders();
            
        }
        }
}
