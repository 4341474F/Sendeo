using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderService.Data;

namespace Order.Service.Queries
{

    public class GetAllOrdersQuery :IRequest<List<OrdersDto>>
    {
        
    }
}
