using System.ComponentModel.DataAnnotations;

namespace LeageBillete_api.Model.Request
{
    public class AuthRequest
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
