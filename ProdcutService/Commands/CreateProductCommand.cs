using MediatR;
using ProductService.Domain;

namespace ProductService.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }
    }
}
