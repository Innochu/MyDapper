using MyDapper.Persistence.DapperContextFolder;
using MyDapper.Persistence.Repository.Interface;

namespace MyDapper.Persistence.Repository.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperContext _dapperContext;

        public EmployeeRepo(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
    }
}
