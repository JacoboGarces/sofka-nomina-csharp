using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Entities;

namespace Sofka.Nomina.Example.Services
{
  public interface IPayrollService
  {
    Employee CalculateSalary(EmployeeDTO payload);
    Payroll CalculatePayroll(List<EmployeeDTO> payload);
  }
}
