using FluentValidation;
using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Factories;
using Sofka.Nomina.Example.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSingleton<IEmployeeFactory, EmployeeFactory>();
builder.Services.AddTransient<IPayrollService, PayrollService>();
builder.Services.AddScoped<IValidator<EmployeeDTO>, EmployeeValidator>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
