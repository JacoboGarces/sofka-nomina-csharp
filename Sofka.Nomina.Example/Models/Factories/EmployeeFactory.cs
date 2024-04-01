using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Entities;
using Sofka.Nomina.Example.Models.Enums;

namespace Sofka.Nomina.Example.Models.Factories
{
  public class EmployeeFactory : IEmployeeFactory
  {
    public Employee Create(EmployeeDTO payload)
    {
      var employeeChildren = new Dictionary<EmployeeType, Employee>
      {
        { EmployeeType.INTERNAL, new Internal(payload.Name, payload.Email, payload.BasicSalary, payload.EntryDate) },
        { EmployeeType.EXTERNAL, new External(payload.Name, payload.Email, payload.BasicSalary, payload.EntryDate) }
      };

      var employee = employeeChildren.GetValueOrDefault(payload.Type);

      if (employee == null)
      {
        throw new ArgumentException("Incorrect Type");
      }

      return employee;
    }
  }
}
