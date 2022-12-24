using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using OrderService.Data;
using OrderService.Domain;

namespace OrderService.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ILogger<CreateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        
        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Order {request.Order.Id} is successfully updated.");
            return await _orderRepository.AddAsync(request.Order);
        }
    }
}
