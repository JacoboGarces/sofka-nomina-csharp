using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Entities;
using Sofka.Nomina.Example.Models.Persistence;

namespace Sofka.Nomina.Example.Services
{
  public interface IPayrollService
  {
    Task<Employee> CalculateSalary(EmployeeDTO payload);
    PayrollEntity CalculatePayroll(List<EmployeeDTO> payload);
  }
}
