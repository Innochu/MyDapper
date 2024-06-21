using Microsoft.AspNetCore.Mvc;
using MyDapper.Application.Service.Interface;
using MyDapper.Domain.Dto;

namespace MyDapper.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeeController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId)
        {
            var employees = await _service.EmployeeService.GetEmployees(companyId);
            return Ok(employees);
        }

        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = await _service.EmployeeService.GetEmployee(companyId, id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("Create-EmployeebyCompanyId")]
        public async Task<IActionResult> CreateEmployeeByCompanyId(Guid companyId, [FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var createemployeebycompanydto = await _service.EmployeeService.CreateEmployee(companyId, createEmployeeDto);

            return Ok(createemployeebycompanydto);
        }

        [HttpPost("create-company-for-employee")]
        public async Task<IActionResult> CreateEmployeeForCompany2(Guid companyId, [FromBody] EmployeeForCreationDto employee)

        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");
            var employeeToReturn = await _service.EmployeeService.CreateEmployeeForCompany(companyId, employee);


            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employee.EmployeeId  }, employeeToReturn);


        }

        [HttpDelete("DeleteEmployee/{id:guid}")]
        
        public async Task<IActionResult> DeleteEmployeeForCompany2(Guid companyId, Guid id)
        {
            await _service.EmployeeService.DeleteEmployeeForCompany(companyId, id);
            return NoContent();
        }

        [HttpPut("Update{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeUpdateDto employee)

        {
            if (employee is null)
                return BadRequest("EmployeeUpdateDto object is null");

            await _service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee);
            return NoContent();
        }
    }
}
