using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Order.Service.Commands
{
    public class UpdateOrderCommand : IRequest
    {
       public OrdersDto Orders { get; set; }

    }
}
