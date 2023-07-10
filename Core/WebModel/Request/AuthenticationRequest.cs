using System.ComponentModel.DataAnnotations;

namespace Core.WebModel.Request
{
    public class AuthenticationRequest
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
