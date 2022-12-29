using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductService.Domain;

namespace ProductService.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IProductRepository orderRepository, IMapper mapper,  ILogger<CreateProductCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        
        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _mapper.Map<Product>(request.Product);
            _logger.LogInformation($"Order {request.Product.Id} is successfully updated.");
            return await _orderRepository.AddAsync(request.Product);
        }
    }
}
