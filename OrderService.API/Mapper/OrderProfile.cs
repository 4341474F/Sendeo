using AutoMapper;
using OrderService.Domain;
using ProductService.Domain;

namespace OrderService.API.Mapper
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            
        }
    }
}
