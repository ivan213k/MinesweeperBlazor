
using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Shared.AuthorizationDtos
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
