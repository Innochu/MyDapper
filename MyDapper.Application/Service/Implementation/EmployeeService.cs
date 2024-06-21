using MyDapper.Application.Service.Interface;
using MyDapper.Domain;
using MyDapper.Domain.Dto;
using MyDapper.Dto;
using MyDapper.Persistence.Repository.Interface;

namespace MyDapper.Application.Service.Implementation
{
   
        internal sealed class EmployeeService : IEmployeeService
        {
            private readonly IRepositoryManager _repository;
           // private readonly ILoggerManager _logger;

            public EmployeeService(IRepositoryManager repository  /* ILoggerManager logger*/)
            {
                _repository = repository;
              //  _logger = logger;
            }

        public Task<Employee> CreateEmployee(Guid companyId, CreateEmployeeDto createEmployeeDto)
        {
          var getcompany = _repository.Company.GetCompany(companyId);
            if (getcompany == null)
            {
                throw new Exception("company does not exist");

            }

            var createemployee = _repository.Employee.CreateEmployee(companyId,createEmployeeDto);
            return createemployee;
        }

        public async Task<EmployeeForCreationDto> CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeDto)
        {
            var company = await _repository.Company.GetCompany(companyId);
            if (company is null)
                throw new InvalidOperationException("company does not exist");

             await _repository.Employee.CreateEmployeeForCompany(companyId, employeeDto);

           var employee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Position = employeeDto.Position,
                CompanyId = companyId,
            };

            var createemployee = new EmployeeForCreationDto()
            {
                Name = employee.Name,
                Age = employee.Age,
                Position = employee.Position,

            };

             return createemployee;
        }

        public async Task DeleteEmployeeForCompany(Guid companyId, Guid employeeId)
        {
            var company = await _repository.Company.GetCompany(companyId);

            if (company is null)
                throw new Exception("company not found");

            var employeeForCompany = _repository
                .Employee.GetEmployee(companyId, employeeId);
            if (employeeForCompany is null)
                throw new Exception("employee not found");

            await _repository.Employee.DeleteEmployee(employeeId);
        }

        public async Task<Employee> GetEmployee(Guid companyId, Guid id)
        {
            var company = await _repository.Company.GetCompany(companyId);
            if (company is null)
            {
                return null;
            }
            var employee = await _repository.Employee.GetEmployee(companyId, id);
            if (employee is null)
               return null;
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees(Guid companyId)
        {
            var company = await _repository.Company.GetCompany(companyId);
            if (company is null)
            {
                return Enumerable.Empty<Employee>();
            }
            var employees = await _repository.Employee.GetEmployees(companyId);
            return employees;
        }

        public async Task UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeUpdateDto employee)
        {
            var company = await _repository.Company.GetCompany(companyId);
            if (company is null)
                throw new InvalidOperationException("company was not found");

            var employeeDto = await _repository.Employee.GetEmployee(companyId, id);
            if (employeeDto is null)
                throw new InvalidOperationException("no employee found");

            await _repository.Employee.UpdateEmployee(id, employee);
        }
    }
    
}
