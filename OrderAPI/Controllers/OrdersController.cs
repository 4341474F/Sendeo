using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Service.Queries;
using OrderService.API.Commands;
using OrderService.Queries;

namespace OrderAPI.Controllers
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

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order.Service.Domain.Order>>> GetOrder()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order.Service.Domain.Order>> GetOrder(string id)
        {
            var orders = await _mediator.Send(new FindAllOrdersByIdQuery(id));
            return Ok(orders);
        }

        /*// GET: api/Orders/5
        [HttpGet("{dateTime}")]
        [Route("date/{dateTime:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
        public async Task<ActionResult> GetOrdersByDateTime(DateTime dateTime)
        {
            var orders = await _mediator.Send(new FindAllOrdersByDateQuery(dateTime));

            //return new JsonResult(orders);    ???
            return Ok(orders);
        }*/

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutOrder([FromBody] UpdateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            //_messagePublisher.SendMessage(request.Orders);

            return new JsonResult(result);
        }

        //// POST: api/Orders
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<OrdersDto>> PostOrder([FromBody] UpdateOrderCommand request)
        //{
        //    var result = await _mediator.Send(request);
        //    _messagePublisher.SendMessage(request.Orders);

        //    return CreatedAtAction("GetOrder", new { id = request.Orders.Id }, request.Orders);
        //}

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
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
