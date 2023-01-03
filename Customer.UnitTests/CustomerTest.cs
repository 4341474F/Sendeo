using AutoMapper;
using CustomerService.API.Mapper;
using CustomerService.Commands;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using CustomerService.Domain;
using CustomerService.Queries;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using OrderService.Commands;
using OrderService.Domain;

namespace Customer.UnitTests
{

    public class CustomerTest
    {
        private static IMapper _mapper;

        public CustomerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CustomerProfile());
                });
                _mapper = mappingConfig.CreateMapper();
            }
        }

        [Fact]
        public async Task GetAllCustomers_ReturnsFromDatabase()
        {
            var mock = new Mock<ICustomerRepository>();
            var mocklogger = new Mock<ILogger<FindCustomerById>>();
            var logger = mocklogger.Object;
            var customer = PopulateTestCustomer();

            mock.Setup(m => m.GetAllCustomers()).ReturnsAsync(new List<CustomerService.Domain.Customer>()
            {
                customer
            });

            var handler = new GetAllCustomersQueryHandler(mock.Object, _mapper, logger);
            var result = await handler.Handle(new FindCustomerById(), CancellationToken.None);

            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<List<CustomerDto>>();
            result[0].Id.Should().BeOfType<string>();
            result[0].Id.Should().Be("1");
        }

        [Fact]
        public async Task FindById_ReturnsFromDatabase()
        {
            var mock = new Mock<ICustomerRepository>();
            var mocklogger = new Mock<ILogger<FindCustomerByIdQuery>>();
            var logger = mocklogger.Object;

            var Customer = PopulateTestCustomer();

            mock.Setup(m => m.FindById(It.Is<string>(id => id == "1"))).ReturnsAsync(Customer);

            var handler = new FindCustomerByIdQueryHandler(mock.Object, _mapper, logger);
            var result = await handler.Handle(new FindCustomerByIdQuery("1"), new CancellationToken());


            result.Should().BeOfType<CustomerDto>();
            result.Id.Should().Be("1");
            result.OrderId.Should().Be("1");
            result.Name.Should().Be("John");
            result.LastName.Should().Be("Doe");
            result.Email.Should().Be("john@sendeo.com");
            result.Address.Should().Be("Address");
        }
        



        [Fact]
        public async Task Add_Customer_ToMockDatabase_ReturnsCustomer()
        {
            var mock = new Mock<ICustomerRepository>();
            var Customer = PopulateTestCustomer();
            //This another test SUT implementation if you don't want to use Mapper 

            mock.Setup(m => m.AddAsync(Customer)).ReturnsAsync(Customer);

            var result = mock.Object.AddAsync(Customer);

            result.Should().BeOfType<Task<CustomerService.Domain.Customer>>();
            result.Result.Id.Should().Be("1");
            result.Result.OrderId.Should().Be("1");
            result.Result.Name.Should().Be("John");
            result.Result.LastName.Should().Be("Doe");
            result.Result.Email.Should().Be("john@sendeo.com");
            result.Result.Address.Should().Be("Address");
        }

        [Fact]
        public async Task Delete_Customer_FromMockDatabase_ReturnsBoolean()
        {
            var mock = new Mock<ICustomerRepository>();
            var order = PopulateTestCustomer();
            var mocklogger = new Mock<ILogger<DeleteCustomerCommandHandler>>();
            var logger = mocklogger.Object;

            mock.Setup(m => m.DeleteAsync("1")).ReturnsAsync("1");

            var result = mock.Object.DeleteAsync("1");

            result.Result.Should().BeOfType<string>();
            result.Result.Should().NotContain("not found");
        }
        private static CustomerService.Domain.Customer PopulateTestCustomer()
        {
            var Customer = new CustomerService.Domain.Customer()
            {
                Id = "1",
                Name = "John",
                LastName = "Doe",
                Email = "john@sendeo.com",
                Address = "Address",
                Phone = "1234567",
                OrderId = "1",
                
            };
            return Customer;
        }
    }
}