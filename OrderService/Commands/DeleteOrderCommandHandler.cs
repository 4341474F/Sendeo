using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OrderService.Domain;

namespace OrderService.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderRepository.FindById(request.Id);
            if (orderToDelete == null)
            {
                throw new Exception( $"Order {request.Id} is not found");
            }

            _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");
            return await _orderRepository.DeleteAsync(request.Id);
        }
    }
}
