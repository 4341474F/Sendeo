using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderAPI.Data;
using OrderAPI.EventBus;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderAPIContext") ?? throw new InvalidOperationException("Connection string 'OrderAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IMessageProducer, Producer>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
