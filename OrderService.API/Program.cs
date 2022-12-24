using Microsoft.EntityFrameworkCore;
using OrderAPI.EventBus;
using MediatR;
using OrderService.API.Data;
using OrderService.API.Domain;
using OrderService.API.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sendeo-db") ?? throw new InvalidOperationException("Connection string 'sendeo-db' not found."), b => b.MigrationsAssembly("OrderService.API")));

// Add services to the container.
builder.Services.AddScoped<IMessageProducer, Producer>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IRequestHandler<GetAllOrdersQuery, List<OrdersDto>>>();
builder.Services.AddMediatR(typeof(GetAllOrdersQuery));
builder.Services.AddControllers();

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
