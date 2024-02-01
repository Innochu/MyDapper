using MyDapper.Domain;

namespace MyDapper.Persistence.Repository.Interface
{
    public interface ICompanyRepo
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompany(Guid id);
    }
}
