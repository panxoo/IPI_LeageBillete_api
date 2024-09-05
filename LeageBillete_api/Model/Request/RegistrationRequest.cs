using System.ComponentModel.DataAnnotations;

namespace LeageBillete_api.Model.Request
{
    public class RegistrationRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
