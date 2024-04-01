using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Entities;

namespace Sofka.Nomina.Example.Models.Factories
{
  public interface IEmployeeFactory
  {
    Employee Create(EmployeeDTO payload);
  }
}
