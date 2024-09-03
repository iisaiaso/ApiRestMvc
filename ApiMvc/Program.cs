using ApiMvc.Controllers.Filters;
using ApiMvc.Controllers.Middlewares;
using ApiMvc.Models.Cores.Context;
using ApiMvc.Service.Cores.Context;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Configurar Serilog
var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
        ".." + Path.DirectorySeparatorChar + "logapi.log",
         LogEventLevel.Warning,
         rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true; // Agregar esto para desabilitar la validación automática
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new DataAccesAutofacModule());
        options.RegisterModule(new BusinessLogicAutofacModule());
    });

// DataAcces
builder.Services.addDataAcces(builder.Configuration);

// Business Logic
builder.Services.addBusinessLogic();


// Validators
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

// API Exception 
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
