using MyDapper.Application.Service.Interface;
using MyDapper.Domain;
using MyDapper.Domain.Dto;
using MyDapper.Persistence.Repository.Interface;

namespace MyDapper.Application.Service.Implementation
{

    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        // private readonly ILoggerManager _logger;
        public CompanyService(IRepositoryManager repository /*ILoggerManager logger*/)
        {
            _repository = repository;
            // _logger = logger;
        }

        public Task<Company> CreateCompany(CompanyForCreationDto company)
        {
            var createcompanies = _repository.Company.CreateCompany( company );
            return createcompanies;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            var companies = await _repository.Company.GetAllCompanies();
            return companies;
        }

        public async Task<IEnumerable<CompanywithEmployee>> GetCompaniesWithEmployees()
        {
            var companies = await _repository.Company.GetCompaniesWithEmployees();
            return companies;
        }

        public async Task<Company> GetCompany(Guid id)
        {
           var companybyId = await _repository.Company.GetCompany(id);
            if (companybyId is null)
            {
                return null;
            }
                
            return companybyId;
        }

       
    }

}
