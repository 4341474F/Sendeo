﻿using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using OrderService.Domain;

namespace OrderService.Queries
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllOrdersQuery> _logger;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<GetAllOrdersQuery> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            
            var orders = await _orderRepository.GetAllOrders();
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
