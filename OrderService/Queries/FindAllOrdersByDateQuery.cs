using MediatR;
using OrderService.API.Data;

namespace OrderService.API.Queries
{

    public class FindAllOrdersByDateQuery :IRequest<List<OrdersDto>>
    {
        private DateTime dateTime;

        public FindAllOrdersByDateQuery(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        
    }
}
