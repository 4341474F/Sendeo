using ProductService.Domain;

namespace OrderService.Domain
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
