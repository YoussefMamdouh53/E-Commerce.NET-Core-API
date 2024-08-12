using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO.UserDTO
{
    public record VerifyUserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
