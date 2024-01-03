using System.ComponentModel.DataAnnotations;

namespace HappyPaws.API.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
    }
}
