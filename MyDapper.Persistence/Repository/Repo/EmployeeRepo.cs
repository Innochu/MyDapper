using Dapper;
using MyDapper.Domain;
using MyDapper.Domain.Dto;
using MyDapper.Dto;
using MyDapper.Persistence.DapperContextFolder;
using MyDapper.Persistence.Query;
using MyDapper.Persistence.Repository.Interface;
using System.ComponentModel.Design;
using System.Data;

namespace MyDapper.Persistence.Repository.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperContext _dapperContext;

        public EmployeeRepo(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<Employee> CreateEmployee(Guid companyId, CreateEmployeeDto createEmployeeDto)
        {
            var createEmployeeQuery = EmployeeQuery.InsertEmployeeWithOutputQuery;
           
            var param = new DynamicParameters(createEmployeeDto);

                param.Add("id", companyId, DbType.Guid);

                using (var connection = _dapperContext.CreateConnection())
                {
                    var id = await connection.QuerySingleAsync<Guid>(createEmployeeQuery, param);

                var newEmployee = new Employee
                {
                    EmployeeId = id,
                    Name = createEmployeeDto.Name,
                    Age = createEmployeeDto.Age,
                    Position = createEmployeeDto.Position

                };

                return newEmployee;

            }

        }

        public async Task<Employee> GetEmployee(Guid companyId, Guid id)
        {
            var GetEmployeequery = EmployeeQuery.SelectEmployeeByIdAndCompanyIdQuery;

            using (var connection = _dapperContext.CreateConnection())
            {
                var param = new { companyId, id };
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(GetEmployeequery, param);
                return employee;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees(Guid companyId)
        {
            var employeesbyid = EmployeeQuery.SelectEmployeesQuery;

            using (var connection = _dapperContext.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(employeesbyid, new { companyId });

                return employees.ToList();
            }
        }

        public async Task<Employee> CreateEmployeeForCompany(Guid companyId,
    EmployeeForCreationDto employeeDto)
        {
            var query = EmployeeQuery.InsertEmployeeWithOutputQuery;

            var param = new DynamicParameters(employeeDto);
            param.Add("id", companyId, DbType.Guid);

            using (var connection = _dapperContext.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<Guid>(query, param);

                var newEmployee = new Employee
                {
                    EmployeeId = id,
                    Name = employeeDto.Name,

                    Age = employeeDto.Age,
                    Position = employeeDto.Position

                };

                return newEmployee;
            }


        }

        public async Task DeleteEmployee(Guid employeeId)
        {
            var query = EmployeeQuery.DeleteEmployeeQuery;

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { employeeId });
            }
        }

        public async Task UpdateEmployee(Guid employeeId, EmployeeUpdateDto employee)
        {
            var query = EmployeeQuery.UpdateEmployeeQuery;

            var param = new DynamicParameters(employee);
            param.Add("employeeId", employeeId, DbType.Guid);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
        }
    }
}
