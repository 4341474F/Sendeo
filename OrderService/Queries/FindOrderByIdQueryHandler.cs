using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using OrderService.Domain;

namespace OrderService.Queries
{
    public class FindOrderByIdQueryHandler : IRequestHandler<FindOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllOrdersQuery> _logger;

        public FindOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<GetAllOrdersQuery> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrderDto> Handle(FindOrderByIdQuery request, CancellationToken cancellationToken)
        {

            var orders = await _orderRepository.FindById(request.Id);
            return _mapper.Map<OrderDto>(orders);
        }

       
    }
}
