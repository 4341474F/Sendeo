using FluentAssertions;
using Moq;
using OrderService.Domain;
using OrderService.Queries;

namespace Order.UnitTests
{

    public class OrderTest 
    {
        [Fact]
        public async Task GetAll_ReturnsJsonResult_WithListOfProducts()
        {
            var mock = new Mock<IOrderRepository>();

            mock.Setup(m => m.FindById(It.Is<string>(id => id == "1"))).ReturnsAsync((OrderService.Domain.Order?)null);

            var handler = new GetAllOrdersQueryHandler(mock.Object);
            var result = await handler.Handle(new GetAllOrdersQuery(), new CancellationToken());

            result.Should().BeNull();
        }
    }
}