using MyDapper.Domain;
using MyDapper.Domain.Dto;

namespace MyDapper.Persistence.Repository.Interface
{
    public interface ICompanyRepo
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompany(Guid id);
        Task<IEnumerable<CompanywithEmployee>> GetCompaniesWithEmployees();
        Task<Company> CreateCompany(CompanyForCreationDto company);
        Task<Company> CreateCompanyWithEmployees(CompanyForCreationDto company);
    }
}
