namespace Sofka.Nomina.Example.Models.Entities
{
  public class PayrollEntity
  {
    public List<EmployeeEntity>? Employees { get; set; }
    public float Total { get; set; }
    public float TotalBonus { get; set; }

    public PayrollEntity()
    {
    }

    public PayrollEntity(List<EmployeeEntity>? employees, float total, float totalBonus)
    {
      Employees = employees;
      Total = total;
      TotalBonus = totalBonus;
    }
  }
}
