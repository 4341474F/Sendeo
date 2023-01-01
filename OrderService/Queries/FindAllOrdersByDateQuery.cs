using MediatR;
using OrderService.Domain;

namespace OrderService.Queries
{

    public class FindAllOrdersByDateQuery :IRequest<List<OrderDto>>
    {
        public DateTime Date { get; }

        public FindAllOrdersByDateQuery(DateTime date)
        {
            Date = date;
        }
        
    }
}
