using System.ComponentModel.DataAnnotations;

namespace Pratik_Jwt.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
