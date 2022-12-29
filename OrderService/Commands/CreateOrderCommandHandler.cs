using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using OrderService.Domain;

namespace OrderService.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CreateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _mapper.Map<Order>(request.Order);
            _logger.LogInformation($"Order {request.Order.Id} is successfully updated.");
            return await _orderRepository.AddAsync(request.Order);
        }
    }
}
