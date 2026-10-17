using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(150)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string EmailAddress { get; set; }
        [Required,Range(3000,100000)]
        public int Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required,ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
