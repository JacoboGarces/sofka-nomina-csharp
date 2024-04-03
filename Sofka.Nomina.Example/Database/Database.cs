using Microsoft.EntityFrameworkCore;
using Sofka.Nomina.Example.Database.Configuration;
using Sofka.Nomina.Example.Database.Interfaces;
using Sofka.Nomina.Example.Models.Persistence;

namespace Sofka.Nomina.Example.Database
{
  public class Database(DbContextOptions options) : DbContext(options), IDatabase
  {
    public DbSet<Employee> Employee { get; set; }

    public async Task<bool> SaveAsync()
    {
      return await SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      EntityConfiguration(modelBuilder);
    }

    private void EntityConfiguration(ModelBuilder modelBuilder)
    {
      new EmployeeConfiguration(modelBuilder.Entity<Employee>());
    }
  }
}
