using MediatR;
using OrderService.Data;

namespace OrderService.Queries
{

    public class FindOrderByIdQuery :IRequest<List<OrdersDto>>
    {
        private string _id { get; set; }
        public FindOrderByIdQuery(string id)
        {
            _id = id;
        }
    }
}
