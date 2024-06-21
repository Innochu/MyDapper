using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDapper.Application.Service.Interface;
using MyDapper.Domain.Dto;

namespace MyDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IServiceManager _service;
        public CompanyController(IServiceManager service) => _service = service;

        [HttpGet("Get-all-companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _service.CompanyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompany(id);
            return Ok(company);
        }

        [HttpGet("withEmployees")]
        public async Task<IActionResult> GetCompaniesWithEmployees()

        {
            var companies = await _service.CompanyService.GetCompaniesWithEmployees();

            return Ok(companies);
        }

        [HttpPost ("create company")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)

        {
            if (company is null)
                return BadRequest("object is null");
            var createdCompany = await _service.CompanyService.CreateCompany(company);
            return CreatedAtRoute("CompanyById",
            new { id = createdCompany.CompanyId }, createdCompany);
        }
    }
}
