using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Sofka.Nomina.Example.Models.DTOS;
using Sofka.Nomina.Example.Services;

namespace Sofka.Nomina.Example.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PayrollController : ControllerBase
  {
    private readonly IPayrollService _payrollService;
    private readonly IValidator<EmployeeDTO> _validator;

    public PayrollController(IPayrollService payrollService, IValidator<EmployeeDTO> validator)
    {
      _payrollService = payrollService;
      _validator = validator;
    }

    [HttpPost("CalculateEmployeeSalary")]
    public async Task<IActionResult> CalculateEmployeeSalary(EmployeeDTO payload)
    {
      var validate = await _validator.ValidateAsync(payload);

      if (!validate.IsValid)
      {
        return StatusCode(StatusCodes.Status400BadRequest, validate.Errors);
      }

      var result = await _payrollService.CalculateSalary(payload);

      if (result == null)
      {
        return StatusCode(StatusCodes.Status400BadRequest, new { Error = "Employee cannot be created" });
      }

      return StatusCode(StatusCodes.Status200OK, result);
    }

    [HttpPost("CalculatePayroll")]
    public async Task<IActionResult> CalculatePayroll(List<EmployeeDTO> payload)
    {
      foreach (var item in payload)
      {
        var validate = await _validator.ValidateAsync(item);

        if (!validate.IsValid)
        {
          return StatusCode(StatusCodes.Status400BadRequest, validate.Errors);
        }
      }

      return StatusCode(StatusCodes.Status200OK, _payrollService.CalculatePayroll(payload));
    }
  }
}
