using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Order.Service.Commands;


namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        
        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        private readonly OrderAPIContext _context;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, ILogger<UpdateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                throw new Exception()
            }
            
            

            await _orderRepository.UpdateAsync(orderToUpdate);

            _logger.LogInformation($"Order {orderToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
