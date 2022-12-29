using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Domain;
using ProductService.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ProdcutApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sendeo-db") ?? throw new InvalidOperationException("Connection string 'sendeo-db' not found."),
        b => b.MigrationsAssembly("ProductService.API")
    ));

// Add services to the container.
//builder.Services.AddScoped<IMessageProducer, Producer>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(GetAllProductsQuery));
//builder.Services.AddMediatR(typeof(CreateProductCommand));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
