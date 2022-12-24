using MediatR;
using OrderService.API.Data;

namespace OrderService.API.Queries
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
