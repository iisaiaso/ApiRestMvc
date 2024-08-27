using ApiMvc.Controllers.Middlewares;
using ApiMvc.Models.Cores.Context;
using ApiMvc.Service.Cores.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DataAcces
builder.Services.addDataAcces(builder.Configuration, Assembly.GetExecutingAssembly());

// Business Logic
builder.Services.addBusinessLogic(Assembly.GetExecutingAssembly());

// API
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
