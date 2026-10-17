using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagementSystem.DTOs
{
    public class AuthLoginDTO
    {
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
    }
}
