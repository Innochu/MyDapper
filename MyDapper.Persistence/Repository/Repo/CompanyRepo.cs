using MyDapper.Persistence.DapperContextFolder;
using MyDapper.Persistence.Repository.Interface;

namespace MyDapper.Persistence.Repository.Repo
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly DapperContext _dapperContext;

        public CompanyRepo(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
    }
}
