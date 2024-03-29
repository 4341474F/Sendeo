﻿using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using CustomerService.Domain;
using OrderService.Queries;

namespace CustomerService.Queries
{
    public class GetAllCustomersQueryHandler : IRequestHandler<FindCustomerById, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FindCustomerById> _logger;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<FindCustomerById> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<CustomerDto>> Handle(FindCustomerById request, CancellationToken cancellationToken)
        {

            var customers = await _customerRepository.GetAllCustomers();
            return _mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
