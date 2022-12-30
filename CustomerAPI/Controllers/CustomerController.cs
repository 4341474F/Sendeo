using CustomerService.Commands;
using CustomerService.Domain;
using CustomerService.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Order
        [HttpGet]
        //[Route("GetOrders")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());

            return Ok(customers);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        //[Route("GetOrder")]
        public async Task<ActionResult<Customer>> GetOrder(string id)
        {
            var orders = await _mediator.Send(new FindCustomerByIdQuery(id));
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult<Customer>> CreateOrder(CreateCustomerCommand request)
        {
            var result = await _mediator.Send(new CreateCustomerCommand { Customer = request.Customer});
            //_messagePublisher.SendMessage(request.Order);

            return result;
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        //[Route("DeleteOrder")]
        public async Task<string> DeleteOrder(DeleteCustomerCommand request, string id)
        {
            return await _mediator.Send(new DeleteCustomerCommand(id));
            
        }

        private async Task<ActionResult<Customer>> OrderExistsAsync(string id)
        {
            var result =  await _mediator.Send(new FindCustomerByIdQuery(id));
            return new JsonResult(result);
        }
    }
}
