using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs.CartDTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
