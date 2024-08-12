using E_Commerce_API.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = String.Empty;

        [Required]
        public string Country { get; set; } = String.Empty;


        public List<Address>? Addresses { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<Cart>? Carts { get; set; }
        public List<Order>? Order { get; set; }
    }
}
