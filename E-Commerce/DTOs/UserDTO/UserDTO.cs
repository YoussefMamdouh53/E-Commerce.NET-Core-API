using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTO.UserDTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Country { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;

    }
}
