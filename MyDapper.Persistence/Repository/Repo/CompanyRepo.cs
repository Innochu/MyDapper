using Dapper;
using MyDapper.Domain;
using MyDapper.Persistence.DapperContextFolder;
using MyDapper.Persistence.Query;
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

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {

            var query = Companyquery.SelectCompanyQuery;
               

            using (var connection = _dapperContext.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        public async Task<Company> GetCompany(Guid id)
        {
            var GetCompanyquery = Companyquery.SelectCompanyByIdQuery;

            using (var connection = _dapperContext.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Company>(GetCompanyquery, new { companyId = id });

                return company;
            }
        }
        
    }
}
