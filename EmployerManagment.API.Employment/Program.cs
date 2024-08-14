using EmployerManagment.Application.Commands.Commands;
using EmployerManagment.Application.Commands.Handlers;
using EmployerManagment.Domain.Services;
using EmployerManagment.Infrastructure.Add;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateNewEmployeeCommand).Assembly));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
