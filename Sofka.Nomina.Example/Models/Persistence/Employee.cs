namespace Sofka.Nomina.Example.Models.Persistence
{
  public class Employee
  {
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public float BasicSalary { get; set; }
    public float TotalSalary { get; set; }
    public float Bonus { get; set; }
    public DateOnly EntryDate { get; set; }

    public override bool Equals(object? obj)
    {
      return obj is Employee employee &&
             EmployeeId == employee.EmployeeId &&
             Name == employee.Name &&
             Email == employee.Email &&
             BasicSalary == employee.BasicSalary &&
             TotalSalary == employee.TotalSalary &&
             Bonus == employee.Bonus &&
             EntryDate.Equals(employee.EntryDate);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(EmployeeId, Name, Email, BasicSalary, TotalSalary, Bonus, EntryDate);
    }
  }
}
