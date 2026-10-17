using CompanyEmployeeManagementSystem.Models;

namespace CompanyEmployeeManagementSystem.Repo.Contract
{
    public interface IEmployee
    {
        Task<List<Employee>> SearchByName(string name);
        Task<List<Employee>> SearchByDepartmentId(int DepartmentId);
    }
}
