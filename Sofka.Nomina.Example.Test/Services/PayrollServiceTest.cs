using Microsoft.EntityFrameworkCore;
using Moq;
using Sofka.Nomina.Example.Database.Interfaces;
using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Models.Entities;
using Sofka.Nomina.Example.Models.Enums;
using Sofka.Nomina.Example.Models.Factories;
using Sofka.Nomina.Example.Models.Persistence;
using Sofka.Nomina.Example.Services;

namespace Sofka.Nomina.Example.Test.Services
{
  public class PayrollServiceTest
  {
    private readonly Mock<IEmployeeFactory> _factoryMock;
    private readonly Mock<DbSet<Employee>> _dbSetMock;
    private readonly Mock<IDatabase> _databaseMock;
    private readonly IPayrollService _payrollService;

    public PayrollServiceTest()
    {
      _dbSetMock = new Mock<DbSet<Employee>>();
      _factoryMock = new Mock<IEmployeeFactory>();
      _databaseMock = new Mock<IDatabase>();
      _databaseMock.SetupGet(database => database.Employee).Returns(_dbSetMock.Object);
      _payrollService = new PayrollService(_factoryMock.Object, _databaseMock.Object);
    }

    [Fact]
    public async void CalculateSalarySuccess()
    {
      var employeeEntity = new ExternalEntity()
      {
        Name = "Test",
        Email = "test@email.com",
        BasicSalary = 3000,
        EntryDate = DateOnly.FromDateTime(new DateTime(2021, 8, 20))
      };


      var employee = new Employee()
      {
        Name = "Test",
        Email = "test@email.com",
        BasicSalary = 3000,
        TotalSalary = 104500,
        Bonus = 100000,
        EntryDate = DateOnly.FromDateTime(new DateTime(2021, 8, 20)),
      };

      var employeeDTO = new EmployeeDTO()
      {
        Name = "Test",
        Email = "test@email.com",
        BasicSalary = 3000,
        EntryDate = DateOnly.FromDateTime(new DateTime(2021, 8, 20)),
        Type = EmployeeType.EXTERNAL
      };

      _factoryMock
        .Setup(factory => factory.Create(It.IsAny<EmployeeDTO>()))
        .Returns(employeeEntity);

      _databaseMock
        .Setup(database => database.SaveAsync())
        .Returns(Task.FromResult(true));

      var result = await _payrollService.CalculateSalary(employeeDTO);

      Assert.NotNull(result);
      Assert.Equal(result, employee);

      _databaseMock.Verify(database => database.Employee.AddAsync(It.IsAny<Employee>(), default), Times.Once);
      _databaseMock.Verify(database => database.SaveAsync(), Times.Once);
      _factoryMock.Verify(factory => factory.Create(It.IsAny<EmployeeDTO>()), Times.Once);
    }
  }
}
