using AutoMapper;
using CompanyEmployeeManagementSystem.DTOs;
using CompanyEmployeeManagementSystem.Models;

namespace CompanyEmployeeManagementSystem.Mapping
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Project, ProjectResponeDTO>();
            CreateMap<ProjectCreateDTO, Project>();
            CreateMap<ProjectUpdateDTO, Project>();
        }
    }
}
