using AutoMapper;
using CustomerService.Domain;
using OrderService.Domain;
using ProductService.Domain;

namespace Customer.API.Mapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerService.Domain.Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerService.Domain.Customer, List<Order>>().ReverseMap();
            CreateMap<Order, List<Product>>().ReverseMap();
            
        }
    }
}
