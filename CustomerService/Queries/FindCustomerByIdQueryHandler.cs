using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using CustomerService.Domain;

namespace CustomerService.Queries
{
    public class FindCustomerByIdQueryHandler : IRequestHandler<FindCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllCustomersQuery> _logger;

        public FindCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<GetAllCustomersQuery> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CustomerDto> Handle(FindCustomerByIdQuery request, CancellationToken cancellationToken)
        {

            var customers = await _customerRepository.FindById(request.Id);
            return _mapper.Map<CustomerDto>(customers);
        }

       
    }
}
