using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Entities;
using Sofka.Nomina.Example.Models.Factories;

namespace Sofka.Nomina.Example.Services
{
  public class PayrollService : IPayrollService
  {
    private readonly IEmployeeFactory _employeeFactory;

    public PayrollService(IEmployeeFactory employeeFactory)
    {
      _employeeFactory = employeeFactory;
    }

    public Employee CalculateSalary(EmployeeDTO payload)
    {
      var employee = _employeeFactory.Create(payload);
      employee.CalcuteSalary();
      return employee;
    }

    public Payroll CalculatePayroll(List<EmployeeDTO> payload)
    {
      var employees = payload.Select(item => _employeeFactory.Create(item)).ToList();

      float totalSalary = 0;
      float totalBonus = 0;

      foreach (var employee in employees)
      {
        totalSalary += employee.CalcuteSalary();
        totalBonus += employee.Bonus;
      }

      return new Payroll(employees, totalSalary, totalBonus);
    }
  }
}
