using CustomerService.Commands;
using CustomerService.Data;
using CustomerService.Domain;
using CustomerService.Queries;
using Microsoft.EntityFrameworkCore;
using MediatR;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sendeo-db") ?? throw new InvalidOperationException("Connection string 'sendeo-db' not found."),
        b => b.MigrationsAssembly("CustomerService.API")
    ));

// Add services to the container.
//builder.Services.AddScoped<IMessageProducer, Producer>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddMediatR(typeof(GetAllCustomersQuery));
builder.Services.AddMediatR(typeof(CreateCustomerCommand));
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