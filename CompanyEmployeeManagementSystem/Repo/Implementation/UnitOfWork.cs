using CompanyEmployeeManagementSystem.Data;
using CompanyEmployeeManagementSystem.Models;
using CompanyEmployeeManagementSystem.Repo.Contract;

namespace CompanyEmployeeManagementSystem.Repo.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly App_Database_Context _db;

        public UnitOfWork(App_Database_Context db, IGenericRepo<User> userGeneric, IGenericRepo<Project> projectGeneric, IGenericRepo<Employee> employeeGeneric, IGenericRepo<EmployeeProject> employeeProjectGeneric, IGenericRepo<Department> departmentGeneric, IEmployee employeeCustom, IEmployeeProject employeeProjectCustom, IAuthRepo authCustom)
        {
            _db = db;
            UserGeneric = userGeneric;
            ProjectGeneric = projectGeneric;
            EmployeeGeneric = employeeGeneric;
            EmployeeProjectGeneric = employeeProjectGeneric;
            DepartmentGeneric = departmentGeneric;
            EmployeeCustom = employeeCustom;
            EmployeeProjectCustom = employeeProjectCustom;
            AuthCustom = authCustom;
        }

        public IGenericRepo<User> UserGeneric { get; }
        public IGenericRepo<Project> ProjectGeneric { get; }
        public IGenericRepo<Employee> EmployeeGeneric { get; }
        public IGenericRepo<EmployeeProject> EmployeeProjectGeneric { get; }
        public IGenericRepo<Department> DepartmentGeneric { get; }
        public IEmployee EmployeeCustom { get; }
        public IEmployeeProject EmployeeProjectCustom { get; }
        public IAuthRepo AuthCustom { get; }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
