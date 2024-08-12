using E_Commerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_API.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string OrderN {  get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Phone { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now; 
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public int AddressId { get; set; }

        public User? User { get; set; }
        public Address? Address { get; set; }
        public List<OrderItem>? Items { get; set; }

    }
}
