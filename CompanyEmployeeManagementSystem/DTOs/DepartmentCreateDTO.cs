using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagementSystem.DTOs
{
    public class DepartmentCreateDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
    }
}
