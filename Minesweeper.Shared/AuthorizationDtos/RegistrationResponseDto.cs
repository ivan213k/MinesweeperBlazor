namespace Minesweeper.Shared.AuthorizationDtos
{
    public class RegistrationResponseDto
    {
        public bool IsRegistrationSuccessful { get; set; }
        public string UserId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
