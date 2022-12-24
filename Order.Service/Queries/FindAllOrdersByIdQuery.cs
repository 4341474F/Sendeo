using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderService.Data;

namespace Order.Service.Queries
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
