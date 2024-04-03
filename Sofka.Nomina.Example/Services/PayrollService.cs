using Sofka.Nomina.Example.Database.Interfaces;
using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Entities;
using Sofka.Nomina.Example.Models.Factories;
using Sofka.Nomina.Example.Models.Persistence;

namespace Sofka.Nomina.Example.Services
{
  public class PayrollService : IPayrollService
  {
    private readonly IEmployeeFactory _employeeFactory;
    private readonly IDatabase _database;

    public PayrollService(IEmployeeFactory employeeFactory, IDatabase database)
    {
      _employeeFactory = employeeFactory;
      _database = database;
    }

    public async Task<Employee> CalculateSalary(EmployeeDTO payload)
    {
      var employeeEntity = _employeeFactory.Create(payload);
      employeeEntity.CalcuteSalary();

      var employee = new Employee()
      {
        Name = employeeEntity.Name,
        Email = employeeEntity.Email,
        BasicSalary = employeeEntity.BasicSalary,
        TotalSalary = employeeEntity.TotalSalary,
        Bonus = employeeEntity.Bonus,
        EntryDate = employeeEntity.EntryDate
      };

      await _database.Employee.AddAsync(employee);

      if (!await _database.SaveAsync())
      {
        return null;
      }

      return employee;
    }

    public PayrollEntity CalculatePayroll(List<EmployeeDTO> payload)
    {
      var employees = payload.Select(item => _employeeFactory.Create(item)).ToList();

      float totalSalary = 0;
      float totalBonus = 0;

      foreach (var employee in employees)
      {
        totalSalary += employee.CalcuteSalary();
        totalBonus += employee.Bonus;
      }

      return new PayrollEntity(employees, totalSalary, totalBonus);
    }
  }
}
