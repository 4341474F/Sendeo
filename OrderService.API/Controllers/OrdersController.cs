using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Commands;
using OrderService.Domain;
using OrderService.Queries;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Order
        [HttpGet]
        //[Route("GetOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        //[Route("GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var orders = await _mediator.Send(new FindOrderByIdQuery(id));
            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{date:datetime}")]
        
        public async Task<ActionResult> GetOrdersByDateTime(DateTime date)
        {
            var orders = await _mediator.Send(new FindAllOrdersByDateQuery(date));

            //return new JsonResult(orders);    ???
            return Ok(orders);
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderCommand request)
        {
            var result = await _mediator.Send(new CreateOrderCommand{Order = request.Order});
            //_messagePublisher.SendMessage(request.Order);

            return result;
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        //[Route("DeleteOrder")]
        public async Task<string> DeleteOrder(DeleteOrderCommand request, string id)
        {
            return await _mediator.Send(new DeleteOrderCommand(id));
            
        }

        private async Task<ActionResult<Order>> OrderExistsAsync(string id)
        {
            var result =  await _mediator.Send(new FindOrderByIdQuery(id));
            return new JsonResult(result);
        }
    }
}
