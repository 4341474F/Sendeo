using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Service;
using Order.Service.Queries;
using OrderAPI.Data;
using OrderAPI.Entities;
using OrderAPI.EventBus;
using System;
using Order.Service.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Azure.Core;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderAPIContext _context;
        private readonly IMessageProducer _messagePublisher;
        private readonly IMediator _mediator;

        public OrdersController(OrderAPIContext context, IMessageProducer messagePublisher, IMediator mediator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _messagePublisher = messagePublisher ?? throw new ArgumentNullException(nameof(messagePublisher)); 
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Order>>> GetOrder()
        {
            var orders = await _mediator.Send(new FindAllOrdersQuery());
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.Order>> GetOrder(string id)
        {
            var orders = await _mediator.Send(new FindAllOrdersByIdQuery(id));
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{dateTime}")]
        public async Task<ActionResult> GetOrdersByDateTime(DateTime dateTime)
        {
            var orders = await _mediator.Send(new FindAllOrdersByDateQuery(dateTime));

            //return new JsonResult(orders);    ???
            return Ok(orders);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromBody] string id, UpdateOrderCommand request)
        {
           
            try
            {
                var result = await _mediator.Send(request);
                _messagePublisher.SendMessage(request.Orders);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersDto>> PostOrder([FromBody] UpdateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            _messagePublisher.SendMessage(request.Orders);

            return CreatedAtAction("GetOrder", new { id = request.Orders.Id }, request.Orders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(string id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
