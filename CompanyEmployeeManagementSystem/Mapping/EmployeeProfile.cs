using AutoMapper;
using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Models;

namespace CompanyEmployeeManagementSystem.Mapping
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeResponeDTO>();
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeUpdateDTO, Employee>();
        }
    }
}
