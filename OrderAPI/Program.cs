using Microsoft.EntityFrameworkCore;
using OrderAPI.EventBus;
using MediatR;
using OrderService.Data;
using OrderService.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderAPIContext") ?? throw new InvalidOperationException("Connection string 'OrderAPIContext' not found.")));

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
