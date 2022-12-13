using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Order.Service.Queries
{

    public class FindAllOrdersQuery :IRequest<List<OrdersDto>>
    {
        
    }
}
