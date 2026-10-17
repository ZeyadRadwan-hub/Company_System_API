using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagementSystem.DTOs
{
    public class EmployeeProjectCreateDTO
    {
        [Required, MaxLength(50)]
        public string AssignedRole { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ProjectId { get; set; }
    }
}
