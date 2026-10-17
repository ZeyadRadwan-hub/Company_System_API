using CompanyEmployeeManagementSystem.Models;

namespace CompanyEmployeeManagementSystem.Repo.Contract
{
    public interface IEmployeeProject
    {
        Task<List<EmployeeProject>> GetByEmployee(int employeeId);
    }
}
