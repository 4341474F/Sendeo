using AutoMapper;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using ProductService.API.Mapper;
using ProductService.Commands;
using ProductService.Domain;
using ProductService.Queries;

namespace Product.UnitTests
{

    public class ProductTest
    {
        private static IMapper _mapper;

        public ProductTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ProductProfile());
                });
                _mapper = mappingConfig.CreateMapper();
            }
        }

        [Fact]
        public async Task GetAllProducts_ReturnsFromDatabase()
        {
            var mock = new Mock<IProductRepository>();
            var mocklogger = new Mock<ILogger<GetAllProductsQueryHandler>>();
            var logger = mocklogger.Object;
            var Product = PopulateTestProduct();

            mock.Setup(m => m.GetAllProducts()).ReturnsAsync(new List<ProductService.Domain.Product>()
            {
                Product
            });

            var handler = new GetAllProductsQueryHandler(mock.Object, _mapper, logger);
            var result = await handler.Handle(new GetAllProductsQuery(), CancellationToken.None);

            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<List<ProductService.Domain.Product>>();
            result[0].Id.Should().BeOfType<string>();
            result[0].Id.Should().Be("1");
        }

        [Fact]
        public async Task FindById_ReturnsFromDatabase()
        {
            var mock = new Mock<IProductRepository>();
            var mocklogger = new Mock<ILogger<FindProductByIdQuery>>();
            var logger = mocklogger.Object;

            var Product = PopulateTestProduct();

            mock.Setup(m => m.FindById(It.Is<string>(id => id == "1"))).ReturnsAsync(Product);

            var handler = new FindProductByIdQueryHandler(mock.Object, _mapper, logger);
            var result = await handler.Handle(new FindProductByIdQuery("1"), new CancellationToken());


            result.Should().BeOfType<ProductService.Domain.ProductDto>();
            result.Name.Should().Be("Product1");
            result.Description.Should().Be("Description1");

        }


        [Fact]
        public async Task Add_Product_ToMockDatabase_ReturnsProduct()
        {
            var mock = new Mock<IProductRepository>();
            var Product = PopulateTestProduct();
            //This another test SUT implementation if you don't want to use Mapper 

            mock.Setup(m => m.AddAsync(Product)).ReturnsAsync(Product);

            var result = mock.Object.AddAsync(Product);

            result.Result.Should().BeOfType<ProductService.Domain.Product>();
            result.Result.Id.Should().Be("1");
            result.Result.OrderId.Should().Be("1");
            result.Result.Name.Should().Be("Product1");
            result.Result.Category.Should().Be("Category1");
            result.Result.Description.Should().Be("Description1");
        }

        [Fact]
        public async Task Delete_Product_FromMockDatabase_ReturnsBoolean()
        {
            var mock = new Mock<IProductRepository>();
            var Product = PopulateTestProduct();
            var mocklogger = new Mock<ILogger<DeleteProductCommandHandler>>();
            var logger = mocklogger.Object;
            
            mock.Setup(m => m.DeleteAsync("1")).ReturnsAsync("1");

            var result = mock.Object.DeleteAsync("1");
            
            result.Result.Should().BeOfType<string>();
            result.Result.Should().NotContain("not found");
        }

        private static ProductService.Domain.Product PopulateTestProduct()
        {
            var Product = new ProductService.Domain.Product
            {
                Id = "1",
                OrderId = "1",
                Name = "Product1",
                Category = "Category1",
                Description = "Description1",
                ImageFile = null,
                Price = 100,
                Stock = 10,


            };
            return Product;
        }
    }
}