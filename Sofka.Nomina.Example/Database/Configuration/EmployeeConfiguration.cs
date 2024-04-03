using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sofka.Nomina.Example.Models.Persistence;

namespace Sofka.Nomina.Example.Database.Configuration
{
  public class EmployeeConfiguration
  {
    public EmployeeConfiguration(EntityTypeBuilder<Employee> entityBuilder)
    {
      entityBuilder.HasKey(entity => entity.EmployeeId);
      entityBuilder.Property(entity => entity.Name).IsRequired();
      entityBuilder.Property(entity => entity.Email).IsRequired();
      entityBuilder.Property(entity => entity.BasicSalary).IsRequired();
      entityBuilder.Property(entity => entity.TotalSalary).IsRequired();
      entityBuilder.Property(entity => entity.Bonus).IsRequired();
      entityBuilder.Property(entity => entity.EntryDate).IsRequired();
    }
  }
}
