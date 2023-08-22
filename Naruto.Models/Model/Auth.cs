using System.ComponentModel.DataAnnotations;

namespace Naruto.Models.Model
{
    public class Auth
    {
        [Key]
        public int IdUser { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
