using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagementSystem.DTOs
{
    public class ProjectCreateDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [Required]
        public DateTime SartDate { get; set; }
        [Required, Range(1000, 1000000)]
        public int Budget { get; set; }
        public int DepartmentId { get; set; }
    }
}
