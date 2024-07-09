using API.DTOs;

namespace API.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> AddEmployeeAsync(EmployeeSaveDto model);
        Task<EmployeeDto> UpdateEmployeeAsync(Guid id, EmployeeSaveDto model);
        Task DeleteEmployeeAsync(Guid id);
    }
}