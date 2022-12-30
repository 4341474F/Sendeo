using AutoMapper;
using CustomerService.Domain;


namespace CustomerAPI.Mapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            
        }
    }
}
