using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Order.UnitTests
{
   
    //public class OrderTest : IClassFixture<WebApplicationFactory<Program>>
    //{ 
    //    private readonly WebApplicationFactory<Program> _factory;

    //    public OrderTest(WebApplicationFactory<Program> factory)
    //    {
    //        _factory = factory;
    //    }

    //    [Fact]
    //    public async Task GetAll_ReturnsJsonResult_WithListOfProducts()
    //    {
    //        var client = _factory.CreateClient();

    //        var response = await client.GetAsync("/api/Products");

    //        response.IsSuccessStatusCode.Should().BeTrue();
    //        response.Content.Headers.ContentType.Should().Be("application/json");
            
    //    }
    //}
}