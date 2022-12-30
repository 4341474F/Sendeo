using AutoMapper;
using CustomerService.Domain;

namespace Customer.API.Mapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerService.Domain.Customer, CustomerDto>().ReverseMap();
            
        }
    }
}
