using E_Commerce_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string SKU { get; set; } = String.Empty;
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public long UnitPriceInPiastres { get; set; } = 0;

        public decimal UnitPriceInPound => UnitPriceInPiastres / 100.0m;

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Review>? Reviews { get; set; }

        public List<Cart>? Carts { get; set; }
        
        public List<OrderItem>? Items { get; set; }


    }
}
