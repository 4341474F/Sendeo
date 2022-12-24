using MediatR;
using OrderService.Data;

namespace OrderService.Queries
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
