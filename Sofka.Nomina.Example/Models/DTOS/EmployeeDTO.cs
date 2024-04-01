using FluentValidation;
using Sofka.Nomina.Example.Models.Enums;

namespace Sofka.Nomina.Example.Models.DTOS
{
  public class EmployeeDTO
  {
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public EmployeeType Type { get; set; }
    public float BasicSalary { get; set; }
    public DateOnly EntryDate { get; set; }
  }

  public class EmployeeValidator : AbstractValidator<EmployeeDTO>
  {
    public EmployeeValidator()
    {
      RuleFor(x => x.Name).NotNull().NotEmpty();
      RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
      RuleFor(x => x.BasicSalary).NotNull().GreaterThan(0);
      RuleFor(x => x.EntryDate).NotNull();
      RuleFor(x => x.Type).NotNull().IsInEnum();
    }
  }
}
