using E_Commerce_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        [Required]
        public string Country { get; set; } = String.Empty;
        [Required]
        public string City { get; set; } = String.Empty;
        [Required]
        public string Region { get; set; } = String.Empty;
        [Required]
        public string PostalCode { get; set; } = String.Empty;
        [Required]
        public string Phone { get; set; } = String.Empty;

        [Required]
        public string UserId { get; set; } = String.Empty;

        public User? User { get; set; }
        public List<Order>? Order { get; set; }
    }
}
