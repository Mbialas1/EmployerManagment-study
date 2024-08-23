using PaycheckManagment.Application.Commands.Commands;
using PaycheckManagment.Domain.Services;
using PaycheckManagment.Infrasctructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddPaymentToUserCommand).Assembly));

builder.Services.AddScoped<IPaycheckRepository, PaycheckRepository>();
builder.Services.AddScoped<IEmployerManagmentService, EmployerManagmentService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
