using MyDapper.Domain;
using MyDapper.Domain.Dto;
using MyDapper.Dto;

namespace MyDapper.Application.Service.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees(Guid companyId);
        Task<Employee> GetEmployee(Guid companyId, Guid id);
        Task<Employee> CreateEmployee(Guid companyId, CreateEmployeeDto createEmployeeDto);
        Task<EmployeeForCreationDto> CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeDto);
        Task DeleteEmployeeForCompany(Guid companyId, Guid employeeId);
        Task UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeUpdateDto employee);

    }
}
