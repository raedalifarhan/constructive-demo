

using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.RequestHelpers
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            // Department
            CreateMap<Department, DepartmentDto>();
            
            CreateMap<DepartmentSaveDto, Department>();


            CreateMap<Department, EmployeeDto>();

            // Employee
            CreateMap<Employee, EmployeeDto>()
                .IncludeMembers(x => x.Department)
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department!.Name));

            CreateMap<Department, EmployeeDto>();

            CreateMap<EmployeeSaveDto, Employee>();
        }
    }

}