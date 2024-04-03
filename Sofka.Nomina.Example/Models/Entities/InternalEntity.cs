namespace Sofka.Nomina.Example.Models.Entities
{
  public class InternalEntity : EmployeeEntity
  {
    public InternalEntity()
    {
    }

    public InternalEntity(string? name, string? email, float basicSalary, DateOnly entryDate) : base(name, email, basicSalary, entryDate)
    {
    }

    public override float CalcuteSalary()
    {
      const float INCREMENT_PERCENTAGE = 10;
      TotalSalary = BasicSalary * (1 + INCREMENT_PERCENTAGE / 100);
      var today = DateOnly.FromDateTime(DateTime.Now);
      var totalDays = today.DayNumber - EntryDate.DayNumber - DAYS_TO_START_HOURS_WORKED;
      var totalHours = totalDays * DAILY_HOURS;

      if (totalHours < 8760)
      {
        Bonus = 100000;
      }
      else if (totalHours < 17520)
      {
        Bonus = 500000;
      }
      else if (totalHours < 26280)
      {
        Bonus = 800000;
      }
      else
      {
        Bonus = 1200000;
      }

      TotalSalary += Bonus;
      return TotalSalary;
    }
  }
}
