using MediatR;
using ProductService.Domain;

namespace ProductService.Queries
{

    public class FindProductByIdQuery :IRequest<List<Product>>
    {
        private string _id { get; set; }
        public FindProductByIdQuery(string id)
        {
            _id = id;
        }
    }
}
