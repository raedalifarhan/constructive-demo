using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> AddEmployeeAsync(EmployeeSaveDto model)
        {
            var employee = _mapper.Map<Employee>(model);
            
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(Guid id, EmployeeSaveDto model)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                throw new Exception("Employee not found");
            }

            _mapper.Map(model, existingEmployee);

            _context.Employees.Update(existingEmployee);

             await _context.SaveChangesAsync();

            return _mapper.Map<EmployeeDto>(existingEmployee);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _context.Employees
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}