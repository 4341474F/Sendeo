using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ProductService.Domain;

namespace ProductService.Queries
{
    public class FindProductByIdQueryHandler : IRequestHandler<FindProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FindProductByIdQuery> _logger;

        public FindProductByIdQueryHandler(IProductRepository ProductRepository, IMapper mapper, ILogger<FindProductByIdQuery> logger)
        {
            _ProductRepository = ProductRepository ?? throw new ArgumentNullException(nameof(ProductRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ProductDto> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {

            var Products = await _ProductRepository.FindById(request.Id);
            return _mapper.Map<ProductDto>(Products);
        }

       
    }
}
