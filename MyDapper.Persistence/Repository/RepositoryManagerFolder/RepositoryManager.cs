using MyDapper.Persistence.DapperContextFolder;
using MyDapper.Persistence.Repository.Interface;
using MyDapper.Persistence.Repository.Repo;

namespace MyDapper.Persistence.Repository.RepositoryManagerFolder
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DapperContext _dapperContext;
        private readonly Lazy<ICompanyRepo> _companyRepository;
        private readonly Lazy<IEmployeeRepo> _employeeRepository;

        public RepositoryManager(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            _companyRepository = new Lazy<ICompanyRepo>(() => new CompanyRepo(_dapperContext));
            _employeeRepository = new Lazy<IEmployeeRepo>(() => new EmployeeRepo(_dapperContext));

        }

        public ICompanyRepo Company => _companyRepository.Value;
        public IEmployeeRepo Employee => _employeeRepository.Value;

     
    }
}
