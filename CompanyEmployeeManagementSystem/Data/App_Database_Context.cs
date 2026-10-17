using CompanyEmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployeeManagementSystem.Data
{
    public class App_Database_Context:DbContext
    {
        public App_Database_Context(DbContextOptions<App_Database_Context> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Employee>()
                .HasOne(x=>x.Department)
                .WithMany(x=>x.Employees)
                .HasForeignKey(x=>x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Projects)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeProjects)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<EmployeeProject>()
                .HasOne(x => x.Project)
                .WithMany(x => x.EmployeeProjects)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeProject>()
            .HasIndex(ep => new 
            {
                ep.EmployeeId, ep.ProjectId 
            })
            .IsUnique();


            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Software Development",
                    Location = "Cairo"
                },
                new Department
                {
                    Id = 2,
                    Name = "Human Resources",
                    Location = "Giza"
                },
                new Department
                {
                    Id = 3,
                    Name = "Finance",
                    Location = "Alexandria"
                }
                );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    EmailAddress = "ahmed@company.com",
                    Salary = 12000,
                    HireDate = new DateTime(2023, 1, 15),
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Omar Ali",
                    EmailAddress = "omar@company.com",
                    Salary = 15000,
                    HireDate = new DateTime(2022, 6, 10),
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Mona Hassan",
                    EmailAddress = "mona@company.com",
                    Salary = 11000,
                    HireDate = new DateTime(2024, 2, 1),
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 4,
                    FullName = "Sara Ahmed",
                    EmailAddress = "sara@company.com",
                    Salary = 9000,
                    HireDate = new DateTime(2023, 8, 20),
                    DepartmentId = 2
                },
                new Employee
                {
                    Id = 5,
                    FullName = "Youssef Samir",
                    EmailAddress = "youssef@company.com",
                    Salary = 10000,
                    HireDate = new DateTime(2024, 3, 12),
                    DepartmentId = 2
                },
                new Employee
                {
                    Id = 6,
                    FullName = "Nour Khaled",
                    EmailAddress = "nour@company.com",
                    Salary = 13000,
                    HireDate = new DateTime(2022, 11, 5),
                    DepartmentId = 3
                },
                new Employee
                {
                    Id = 7,
                    FullName = "Ali Mahmoud",
                    EmailAddress = "ali@company.com",
                    Salary = 18000,
                    HireDate = new DateTime(2021, 5, 17),
                    DepartmentId = 3
                },
                new Employee
                {
                    Id = 8,
                    FullName = "Salma Tarek",
                    EmailAddress = "salma@company.com",
                    Salary = 14000,
                    HireDate = new DateTime(2023, 9, 25),
                    DepartmentId = 1
                }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Company Website",
                    Description = "Develop the company website",
                    SartDate = new DateTime(2025, 1, 1),
                    Budget = 150000,
                    DepartmentId = 1
                },
                new Project
                {
                    Id = 2,
                    Name = "Employee Portal",
                    Description = "Internal employee management portal",
                    SartDate = new DateTime(2025, 2, 1),
                    Budget = 250000,
                    DepartmentId = 1
                },
                new Project
                {
                    Id = 3,
                    Name = "Recruitment System",
                    Description = "Manage recruitment processes",
                    SartDate = new DateTime(2025, 3, 1),
                    Budget = 80000,
                    DepartmentId = 2
                },
                new Project
                {
                    Id = 4,
                    Name = "Financial Dashboard",
                    Description = "Financial reports and analytics",
                    SartDate = new DateTime(2025, 4, 1),
                    Budget = 200000,
                    DepartmentId = 3
                }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 1,
                    EmployeeId = 1,
                    ProjectId = 1,
                    AssignedRole = "Backend Developer",
                    AssignedDate = new DateTime(2025, 1, 5)
                },
                new EmployeeProject
                {
                    Id = 2,
                    EmployeeId = 2,
                    ProjectId = 1,
                    AssignedRole = "Frontend Developer",
                    AssignedDate = new DateTime(2025, 1, 6)
                },
                new EmployeeProject
                {
                    Id = 3,
                    EmployeeId = 3,
                    ProjectId = 2,
                    AssignedRole = "Database Developer",
                    AssignedDate = new DateTime(2025, 2, 5)
                },
                new EmployeeProject
                {
                    Id = 4,
                    EmployeeId = 4,
                    ProjectId = 3,
                    AssignedRole = "HR Specialist",
                    AssignedDate = new DateTime(2025, 3, 5)
                },
                new EmployeeProject
                {
                    Id = 5,
                    EmployeeId = 6,
                    ProjectId = 4,
                    AssignedRole = "Financial Analyst",
                    AssignedDate = new DateTime(2025, 4, 5)
                },
                new EmployeeProject
                {
                    Id = 6,
                    EmployeeId = 7,
                    ProjectId = 4,
                    AssignedRole = "Project Manager",
                    AssignedDate = new DateTime(2025, 4, 6)
                }
            );


        }
    } 
}
