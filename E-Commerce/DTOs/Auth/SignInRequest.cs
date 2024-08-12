using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs.Auth
{
    public class SignInRequest
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
