using AutoMapper;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using OrderService.API.Mapper;
using OrderService.Commands;
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
            var mocklogger = new Mock<ILogger<FindOrderByIdQuery>>();
            var logger = mocklogger.Object;

            var order = PopulateTestOrder();

            mock.Setup(m => m.FindById(It.Is<string>(id => id == "1"))).ReturnsAsync(order);

            var handler = new FindOrderByIdQueryHandler(mock.Object, _mapper, logger);
            var result = await handler.Handle(new FindOrderByIdQuery("1"), new CancellationToken());


            result.Should().BeOfType<OrderDto>();
            result.Id.Should().Be("1");
            result.Products.Should().BeOfType<List<ProductDto>>();
            result.CustomerId.Should().NotBe(null);
            result.CustomerId.Should().Be("1");
            result.ImageFile.Should().Be(null);
        }
        [Fact]
        public async Task FindByDate_ReturnsFromDatabase()
        {
            var mock = new Mock<IOrderRepository>();
            var mocklogger = new Mock<ILogger<FindAllOrdersByDateQuery>>();
            var logger = mocklogger.Object;

            var order = PopulateTestOrder();

            mock.Setup(m => m.FindByDate(It.Is<DateTime>(date => date == DateTime.Today))).ReturnsAsync(order);

            var handler = new FindAllOrdersByDateQueryHandler(mock.Object, _mapper, logger);
            //var result = await handler.Handle(new FindAllOrdersByDateQuery(DateTime.Today), new CancellationToken());

            var result = mock.Object.FindByDate(DateTime.Today);
            result.Result.Should().BeOfType<OrderService.Domain.Order>();
            result.Result.Id.Should().Be("1");
            result.Result.CustomerId.Should().Be("1");
            result.Result.OrderDate.Should().Be(DateTime.Today);
            result.Result.Products.Should().BeOfType<List<Product>>();
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
            result.Result.CustomerId.Should().Be("1");
            result.Result.OrderDate.Should().Be(DateTime.Today);
            result.Result.Products.Should().AllBeOfType<Product>();
        }

        [Fact]
        public async Task Delete_Order_FromMockDatabase_ReturnsBoolean()
        {
            var mock = new Mock<IOrderRepository>();
            var order = PopulateTestOrder();
            var mocklogger = new Mock<ILogger<DeleteOrderCommandHandler>>();
            var logger = mocklogger.Object;
            
            mock.Setup(m => m.DeleteAsync("1")).ReturnsAsync("1");

            var result = mock.Object.DeleteAsync("1");
            
            result.Result.Should().BeOfType<string>();
            result.Result.Should().NotContain("not found");
        }

        private static OrderService.Domain.Order PopulateTestOrder()
        {
            var order = new OrderService.Domain.Order
            {
                Id = "1",
                CustomerId = "1",
                OrderDate = DateTime.Today,
                Products = new List<Product>()
                {
                    new()
                    {
                        Name = "Product",
                        Category = "Category",
                        Description = "Desc",
                        ImageFile = "",
                        Price = 10,
                        Stock = 2,
                        Id = "1",
                        OrderId = "1"
                    }
                }
            };
            return order;
        }
    }
}