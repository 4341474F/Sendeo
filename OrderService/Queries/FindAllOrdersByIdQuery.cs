using MediatR;
using OrderService.Data;

namespace OrderService.Queries
{

    public class FindAllOrdersByIdQuery :IRequest<List<OrdersDto>>
    {
        private string _id { get; set; }
        public FindAllOrdersByIdQuery(string id)
        {
            _id = id;
        }

        
        
    }
}
