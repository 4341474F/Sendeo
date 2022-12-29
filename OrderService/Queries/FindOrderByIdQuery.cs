using MediatR;
using OrderService.Domain;

namespace OrderService.Queries
{

    public class FindOrderByIdQuery :IRequest<OrderDto>
    {
        public string Id { get; }

        public FindOrderByIdQuery(string id)
        {
            Id = id;
        }   
    }
}
