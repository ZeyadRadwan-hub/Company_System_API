using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployeeManagementSystem.Models
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }

        [Required]
        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
