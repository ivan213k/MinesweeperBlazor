using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Shared.AuthorizationDtos
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
