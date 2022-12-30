using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using CustomerService.Domain;

namespace CustomerService.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            _mapper.Map<Customer>(request.Customer);
            _logger.LogInformation($"Customer {request.Customer.Id} is successfully updated.");
            return await _customerRepository.AddAsync(request.Customer);
        }
    }
}
