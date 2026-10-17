using CompanyEmployeeManagementSystem.Data;
using CompanyEmployeeManagementSystem.Models;
using CompanyEmployeeManagementSystem.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployeeManagementSystem.Repo.Implementation
{
    public class EmployeeProjectRepo: IEmployeeProject
    {
        private readonly App_Database_Context _db;

        public EmployeeProjectRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task<List<EmployeeProject>> GetByEmployee(int employeeId)
        {
            var x = await _db.EmployeeProjects.Where(x => x.EmployeeId == employeeId).ToListAsync();
            return x;
        }
    }
}
