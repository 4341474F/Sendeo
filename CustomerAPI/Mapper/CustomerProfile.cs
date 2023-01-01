using AutoMapper;
using CustomerService.Domain;
using OrderService.Domain;
using ProductService.Domain;

namespace CustomerService.API.Mapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Domain.Customer, CustomerDto>().ReverseMap();
            CreateMap<Domain.Customer, List<Order>>().ReverseMap();
            CreateMap<Order, List<Product>>().ReverseMap();
            
        }
    }
}
