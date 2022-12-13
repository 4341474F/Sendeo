using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Order.Service.Queries
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
