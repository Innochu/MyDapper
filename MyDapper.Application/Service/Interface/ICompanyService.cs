using MyDapper.Domain;
using MyDapper.Dto;

namespace MyDapper.Application.Service.Interface
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompany(Guid id);
    }
}
