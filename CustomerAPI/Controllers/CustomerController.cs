using AutoMapper;
using CustomerService.Commands;
using CustomerService.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerService.Domain.Customer>>> GetCustomer()
        {
            
            var customers = await _mediator.Send(new GetAllCustomersQuery());

            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        //[Route("GetCustomer")]
        public async Task<ActionResult<CustomerService.Domain.Customer>> GetCustomer(string id)
        {
            var customers = await _mediator.Send(new FindCustomerByIdQuery(id));
            return Ok(customers);
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<ActionResult<CustomerService.Domain.Customer>> CreateCustomer(CreateCustomerCommand request)
        {
            var result = await _mediator.Send(new CreateCustomerCommand { Customer = request.Customer});
            //_messagePublisher.SendMessage(request.Customer);

            return result;
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        //[Route("DeleteCustomer")]
        public async Task<string> DeleteCustomer(DeleteCustomerCommand request, string id)
        {
            return await _mediator.Send(new DeleteCustomerCommand(id));
            
        }

        private async Task<ActionResult<CustomerService.Domain.Customer>> CustomerExistsAsync(string id)
        {
            var result =  await _mediator.Send(new FindCustomerByIdQuery(id));
            return new JsonResult(result);
        }
    }
}
