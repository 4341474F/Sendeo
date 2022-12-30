using MediatR;
using OrderService.Domain;

namespace OrderService.Queries
{

    public class FindAllOrdersByDateQuery :IRequest<List<OrderDto>>
    {
        private DateTime dateTime;

        public FindAllOrdersByDateQuery(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        
    }
}
