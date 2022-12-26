using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Commands;
using ProductService.Domain;
using ProductService.Queries;

namespace ProductService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _mediator.Send(new FindProductByIdQuery(id));

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(CreateProductCommand request)
        {
            
            _mediator.Send(new CreateProductCommand { Product = request.Product});
          
            return CreatedAtAction("GetProduct", new { id = request.Product.Id }, request);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteProduct(string id)
        {
            var product = await _mediator.Send(new FindProductByIdQuery(id));
            if (product == null)
            {
                return "Specified Product is not found!";
            }

            return await _mediator.Send(new DeleteProductCommand(id));
        }
    }
}
