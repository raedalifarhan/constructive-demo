using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);
            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto> AddDepartmentAsync(DepartmentSaveDto model)
        {
            var department = _mapper.Map<Department>(model);

            if (_context.Departments.Any(x => x.Name == model.Name))
                throw new Exception("department already exists!");

            _context.Departments.Add(department);

            await _context.SaveChangesAsync();

            return _mapper.Map<DepartmentDto>(department);
        }

        public async Task<DepartmentDto> UpdateDepartmentAsync(Guid id, DepartmentSaveDto model)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null)
            {
                throw new Exception("Department not found");
            }

            if (_context.Departments.Any(x => x.Name == model.Name))
                throw new Exception("department already exists!");

            _mapper.Map(model, existingDepartment);

            _context.Departments.Update(existingDepartment);

            await _context.SaveChangesAsync();

            return _mapper.Map<DepartmentDto>(existingDepartment);
        }

        public async Task DeleteDepartmentAsync(Guid id)
        {
            await _context.Departments
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}