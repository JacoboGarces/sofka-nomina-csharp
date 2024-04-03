using Microsoft.EntityFrameworkCore;
using Sofka.Nomina.Example.Models.Persistence;

namespace Sofka.Nomina.Example.Database.Interfaces
{
  public interface IDatabase
  {
    DbSet<Employee> Employee { get; set; }
    Task<bool> SaveAsync();
  }
}
