using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using CustomerService.Domain;

namespace CustomerService.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly ICustomerRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository orderRepository, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
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
