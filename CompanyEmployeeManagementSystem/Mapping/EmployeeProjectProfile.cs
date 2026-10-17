using AutoMapper;
using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Models;

namespace CompanyEmployeeManagementSystem.Mapping
{
    public class EmployeeProjectProfile:Profile
    {
        public EmployeeProjectProfile() 
        {
            CreateMap<EmployeeProject, EmployeeProjectResponeDTO>();
            CreateMap<EmployeeProjectCreateDTO, EmployeeProject>();
            CreateMap<EmployeeProjectUpdateDTO, EmployeeProject>();
        }
    }
}
