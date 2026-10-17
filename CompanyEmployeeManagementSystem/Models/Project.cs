using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployeeManagementSystem.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime SartDate { get; set; }
        [Required,Range(1000,1000000)]
        public int Budget {  get; set; }
        [Required, ForeignKey(nameof(DepartmentId))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    }
}
