using MediatR;
using ProductService.Domain;

namespace ProductService.Queries
{

    public class FindProductByIdQuery :IRequest<List<ProductDto>>, IRequest<ProductDto>
    {
        public string Id { get; }
        public FindProductByIdQuery(string id)
        {
            Id = id;
        }
    }
}
