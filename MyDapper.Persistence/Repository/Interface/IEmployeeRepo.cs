using MyDapper.Domain;
using MyDapper.Domain.Dto;
using MyDapper.Dto;

namespace MyDapper.Persistence.Repository.Interface
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetEmployees(Guid companyId);
        Task<Employee> GetEmployee(Guid companyId, Guid id);
        Task<Employee> CreateEmployee(Guid companyId, CreateEmployeeDto createEmployeeDto);
        Task<Employee> CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeDto);
        Task DeleteEmployee(Guid employeeId);
        Task UpdateEmployee(Guid employeeId, EmployeeUpdateDto employee);
    }
}
