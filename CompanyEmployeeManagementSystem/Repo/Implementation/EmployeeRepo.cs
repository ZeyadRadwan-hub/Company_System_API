using CompanyEmployeeManagementSystem.Data;
using CompanyEmployeeManagementSystem.Models;
using CompanyEmployeeManagementSystem.Repo.Contract;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployeeManagementSystem.Repo.Implementation
{
    public class EmployeeRepo:IEmployee
    {
        private readonly App_Database_Context _db;

        public EmployeeRepo(App_Database_Context db)
        {
            _db = db;
        }

        public async Task<List<Employee>> SearchByDepartmentId(int DepartmentId)
        {
            var x = await _db.Employees.Where(x=>x.DepartmentId==DepartmentId).ToListAsync();
            return x;
        }

        public async Task<List<Employee>> SearchByName(string name)
        {
            var x = await _db.Employees.Where(x => x.FullName.Contains(name)).ToListAsync();
            return x;
        }
    }
}
