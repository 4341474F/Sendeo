using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using OrderService.Domain;

namespace OrderService.Queries
{
    public class FindAllOrdersByDateQueryHandler : IRequestHandler<FindAllOrdersByDateQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FindAllOrdersByDateQuery> _logger;

        public FindAllOrdersByDateQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<FindAllOrdersByDateQuery> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<List<OrderDto>> Handle(FindAllOrdersByDateQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.FindByDate(request.Date);
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
