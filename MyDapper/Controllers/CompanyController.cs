using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDapper.Application.Service.Interface;

namespace MyDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IServiceManager _service;
        public CompanyController(IServiceManager service) => _service = service;

        [HttpGet ("Get-all-companies")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _service.CompanyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompany(id);
            return Ok(company);
        }

    }
}
