using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using CustomerService.Domain;

namespace CustomerService.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerToDelete = await _customerRepository.FindById(request.Id);
            if (customerToDelete == null)
            {
                throw new Exception( $"Customer {request.Id} is not found");
            }

            _logger.LogInformation($"Customer {customerToDelete.Id} is successfully deleted.");
            return await _customerRepository.DeleteAsync(request.Id);
        }
    }
}
