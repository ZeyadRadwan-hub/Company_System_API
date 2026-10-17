using AutoMapper;
using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Models;

namespace CompanyEmployeeManagementSystem.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentResponeDTO>();
            CreateMap<DepartmentCreateDTO, Department>();
            CreateMap<DepartmentUpdateDTO, Department>();
        }
    }
}
