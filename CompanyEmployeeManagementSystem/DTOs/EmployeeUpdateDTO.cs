using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagementSystem.DTOs
{
    public class EmployeeUpdateDTO
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required, Range(3000, 100000)]
        public int Salary { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
