using Dapper;
using MyDapper.Domain;
using MyDapper.Domain.Dto;
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

        public async Task<IEnumerable<CompanywithEmployee>> GetCompaniesWithEmployees()
        {
            var GetCompaniesWithEmployeesquery = Companyquery.SelectCompaniesWithEmployeesQuery;

            using (var connection = _dapperContext.CreateConnection())
            {
                var companyDict = new Dictionary<Guid, CompanywithEmployee>();

                var companies = await connection.QueryAsync<CompanywithEmployee, Employee, CompanywithEmployee>
                    (
                    GetCompaniesWithEmployeesquery, (company, employee) =>
                    {
                        if (!companyDict.TryGetValue(company.CompanyId, out var
        currentCompany))
                        {
                            currentCompany = company;
                            companyDict.Add(currentCompany.CompanyId, currentCompany);
                        }

                        currentCompany.Employees.Add(employee);

                        return currentCompany;
                    }, splitOn: "CompanyId, EmployeeId"
                );

                return companies.Distinct().ToList();
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

        public async Task<Company> CreateCompany(CompanyForCreationDto company)
        {
            var CreateCompanyquery = Companyquery.InsertCompanyQuery;
            var param = new DynamicParameters(company);

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Guid>(CreateCompanyquery, param);

                // Using the record constructor to create a new Company instance
                var newCompany = new Company
                {
                    CompanyId = id,
                    Name = company.Name,
                    Address = company.Address,
                    Country = company.Country
                };

                return newCompany;
            }
        }

        public async Task<Company> CreateCompanyWithEmployees(CompanyForCreationDto company)

        {
            var query = Companyquery.InsertCompanyQuery;

            var param = new DynamicParameters(company);

            using (var connection = _dapperContext.CreateConnection())
            {
                connection.Open();

                using (var trans = connection.BeginTransaction())
                {
                    var id = await connection
                        .QuerySingleAsync<Guid>(query, param, transaction: trans);

                    var queryEmp = EmployeeQuery.InsertEmployeeNoOutputQuery;

                    var empList = company.EmployeeForCreationDtos
                        .Select(e => new { e.Name, e.Age, e.Position, id });

                    await connection.ExecuteAsync(queryEmp, empList, transaction: trans);

                    trans.Commit();

                    var newCompany = new Company
                    {
                        CompanyId = id,
                        Name = company.Name,
                        Address = company.Address,
                        Country = company.Country
                    };

                    return newCompany;
                }
            }
        }
    }
}
