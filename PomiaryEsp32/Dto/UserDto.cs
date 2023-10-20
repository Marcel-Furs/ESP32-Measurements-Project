using System.ComponentModel.DataAnnotations;

namespace PomiaryEsp32.Dto
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
