using MyDapper.Domain;
using MyDapper.Domain.Dto;
using MyDapper.Dto;

namespace MyDapper.Application.Service.Interface
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompany(Guid id);
        Task<IEnumerable<CompanywithEmployee>> GetCompaniesWithEmployees();
        Task<Company> CreateCompany(CompanyForCreationDto company);
       

    }
}
