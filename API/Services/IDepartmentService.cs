using API.DTOs;

namespace API.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> GetDepartmentByIdAsync(Guid id);
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto> AddDepartmentAsync(DepartmentSaveDto model);
        Task<DepartmentDto> UpdateDepartmentAsync(Guid id, DepartmentSaveDto model);
        Task DeleteDepartmentAsync(Guid id);
    }
}