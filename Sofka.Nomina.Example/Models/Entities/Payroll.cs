namespace Sofka.Nomina.Example.Models.Entities
{
  public class Payroll
  {
    public List<Employee>? Employees { get; set; }
    public float Total { get; set; }
    public float TotalBonus { get; set; }

    public Payroll()
    {
    }

    public Payroll(List<Employee>? employees, float total, float totalBonus)
    {
      Employees = employees;
      Total = total;
      TotalBonus = totalBonus;
    }
  }
}
