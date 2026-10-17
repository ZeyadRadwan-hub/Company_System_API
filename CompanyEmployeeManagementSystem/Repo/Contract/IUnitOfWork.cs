using CompanyEmployeeManagementSystem.Models;

namespace CompanyEmployeeManagementSystem.Repo.Contract
{
    public interface IUnitOfWork
    {
        IGenericRepo<User> UserGeneric { get; }
        IGenericRepo<Project> ProjectGeneric { get; }
        IGenericRepo<Employee> EmployeeGeneric { get; }
        IGenericRepo<EmployeeProject> EmployeeProjectGeneric { get; }
        IGenericRepo<Department> DepartmentGeneric { get; }
        IEmployee EmployeeCustom { get; }
        IEmployeeProject EmployeeProjectCustom { get; }
        IAuthRepo AuthCustom { get; }
        Task<int> SaveAsync();
    }
}
