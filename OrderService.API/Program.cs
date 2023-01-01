using Microsoft.EntityFrameworkCore;
using MediatR;
using OrderService.Commands;
using OrderService.API.EventBus;
using OrderService.Data;
using OrderService.Domain;
using OrderService.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<OrderApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sendeo-db") ?? throw new InvalidOperationException("Connection string 'sendeo-db' not found."), 
        b => b.MigrationsAssembly("OrderService.API")
    ));

// Add services to the container.
builder.Services.AddScoped<IMessageProducer, Producer>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddMediatR(typeof(GetAllOrdersQuery));
builder.Services.AddMediatR(typeof(FindOrderByIdQuery));
builder.Services.AddMediatR(typeof(FindAllOrdersByDateQuery));
builder.Services.AddMediatR(typeof(CreateOrderCommand));
builder.Services.AddMediatR(typeof(DeleteOrderCommand));
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
