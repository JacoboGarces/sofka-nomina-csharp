namespace Sofka.Nomina.Example.Models.Entities
{
  public abstract class EmployeeEntity
  {
    public string? Name { get; set; }
    public string? Email { get; set; }
    public float BasicSalary { get; set; }
    public float TotalSalary { get; set; }
    public float Bonus { get; set; }
    public DateOnly EntryDate { get; set; }
    protected readonly int DAYS_TO_START_HOURS_WORKED = 1;
    protected readonly int DAILY_HOURS = 8;

    protected EmployeeEntity()
    {

    }

    protected EmployeeEntity(string? name, string? email, float basicSalary, DateOnly entryDate)
    {
      Name = name;
      Email = email;
      BasicSalary = basicSalary;
      EntryDate = entryDate;
    }

    public abstract float CalcuteSalary();
  }
}
