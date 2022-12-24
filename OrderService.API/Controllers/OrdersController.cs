using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Commands;
using OrderService.Data;
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
            var orders = await _mediator.Send(new FindAllOrdersByIdQuery(id));
            return Ok(orders);
        }

        /*// GET: api/Order/5
        [HttpGet("{dateTime}")]
        [Route("date/{dateTime:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
        public async Task<ActionResult> GetOrdersByDateTime(DateTime dateTime)
        {
            var orders = await _mediator.Send(new FindAllOrdersByDateQuery(dateTime));

            //return new JsonResult(orders);    ???
            return Ok(orders);
        }*/

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        //[Route("PutOrder")]
        public async Task<IActionResult> PutOrder(UpdateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            //_messagePublisher.SendMessage(request.Order);

            return new JsonResult(result);
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PostOrder")]
        public async Task<ActionResult<Order>> PostOrder( CreateOrderCommand request)
        {
            var result = await _mediator.Send(new CreateOrderCommand{Order = request.Order});
            //_messagePublisher.SendMessage(request.Order);

            return result;
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        //[Route("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand() { Id = id });
            return new JsonResult(result);
        }

        private async Task<IActionResult> OrderExistsAsync(string id)
        {
            var result =  await _mediator.Send(new FindAllOrdersByIdQuery(id));
            return new JsonResult(result);
        }
    }
}
