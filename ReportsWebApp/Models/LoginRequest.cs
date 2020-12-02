using System.ComponentModel.DataAnnotations;

namespace ReportsWebApp.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
