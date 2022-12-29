using AutoMapper;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using OrderService.API.Mapper;
using OrderService.Domain;
using OrderService.Queries;
using ProductService.Domain;

namespace Order.UnitTests
{

    public class OrderTest
    {
        private static IMapper _mapper;

        public OrderTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new OrderProfile());
                });
                _mapper = mappingConfig.CreateMapper();
            }
        }

        [Fact]
        public async Task GetAllOrders_ReturnsFromDatabase()
        {
            var mock = new Mock<IOrderRepository>();
            var mocklogger = new Mock<ILogger<GetAllOrdersQuery>>();
            var logger = mocklogger.Object;
            var order = PopulateTestOrder();

            mock.Setup(m => m.GetAllOrders()).ReturnsAsync(new List<OrderService.Domain.Order>()
            {
                order
            });

            var handler = new GetAllOrdersQueryHandler(mock.Object, _mapper, logger);
            var result = await handler.Handle(new GetAllOrdersQuery(), CancellationToken.None);

            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<List<OrderDto>>();
            result[0].Id.Should().BeOfType<string>();
            result[0].Id.Should().Be("1");
        }

        [Fact]
        public async Task FindById_ReturnsFromDatabase()
        {
            var mock = new Mock<IOrderRepository>();
            var mocklogger = new Mock<ILogger<GetAllOrdersQuery>>();
            var logger = mocklogger.Object;
            
            var order = PopulateTestOrder();

            mock.Setup(m => m.FindById(It.Is<string>(id => id == "1"))).ReturnsAsync(order);

            var handler = new FindOrderByIdQueryHandler(mock.Object, _mapper, logger);
            var result = await handler.Handle(new FindOrderByIdQuery("1"), new CancellationToken());


            result.Should().BeOfType<OrderDto>();
            result.Id.Should().Be("1");
        }



        [Fact]
        public async Task Add_Order_ToMockDatabase_ReturnsOrder()
        {
            var mock = new Mock<IOrderRepository>();
            var order = PopulateTestOrder();
            //This another test SUT implementation if you don't want to use Mapper 

            mock.Setup(m => m.AddAsync(order)).ReturnsAsync(order);

            var result = mock.Object.AddAsync(order);

            result.Result.Should().BeOfType<OrderService.Domain.Order>();
            result.Result.Id.Should().Be("1");
            result.Result.Address.Should().Be("Adress");
            result.Result.Email.Should().Be("order@sendeo.com");
            result.Result.Name.Should().Be("Order1");
            result.Result.OrderNo.Should().Be("1");
            result.Result.Phone.Should().Be("1234567");
            result.Result.Products.Should().AllBeOfType<Product>();
        }

        private static OrderService.Domain.Order PopulateTestOrder()
        {
            var order = new OrderService.Domain.Order()
            {
                Id = "1",
                Address = "Adress",
                Email = "order@sendeo.com",
                Name = "Order1",
                OrderDate = new DateTime(),
                OrderNo = "1",
                Phone = "1234567",
                Products = new List<Product>() {new() {Name = "Product", Id = "1"}}
            };
            return order;
        }
    }
}