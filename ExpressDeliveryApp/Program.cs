using System.Reflection;
using ExpressDeliveryApp.ExceptionHandling;
using ExpressDeliveryApp.Extensions;
using ExpressDeliveryApp.Repository.Implementation;
using ExpressDeliveryApp.Repository.Interfaces;
using ExpressDeliveryApp.Service.Implementation;
using ExpressDeliveryApp.Service.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation();

// Services
builder.Services.AddScoped<ICourierService, CourierService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.ConfigureAndAddTextSearch();
// Database
builder.Services.AddSingleton<ITicketRepository, InMemoryTicketRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();