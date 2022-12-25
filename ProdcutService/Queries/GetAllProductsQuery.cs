using MediatR;
using ProductService.Domain;

namespace ProductService.Queries
{

    public class GetAllProductsQuery :IRequest<List<Product>>
    {
        
    }
}
