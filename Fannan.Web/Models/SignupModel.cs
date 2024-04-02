using System.ComponentModel.DataAnnotations;

namespace Fannan.Web.Models
{
    public class SignupModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username should be at least 3 characters")]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [MinLength(3, ErrorMessage = "First name should be at least 3 characters")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MinLength(3, ErrorMessage = "Last name should be at least 3 characters")]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
