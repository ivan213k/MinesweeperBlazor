using Microsoft.AspNetCore.Identity;

namespace MinesweeperServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
