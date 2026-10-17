using System.ComponentModel.DataAnnotations;

namespace CompanyEmployeeManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(150),MinLength(20)]
        public string Name { get; set; }
        [Required, EmailAddress,MaxLength(100)]
        public string Email { get; set; }
        [Required,MaxLength(100)]
        public string Password { get; set; }
        [Required,MaxLength(30)]
        public string Role { get; set; }
    }
}
