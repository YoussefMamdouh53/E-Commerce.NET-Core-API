using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs.ProductDTO
{
    public record ProductDTO
    {
        public string? SKU { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; } = 0;
        public long UnitPriceInPiastres { get; set; } = 0;
        public int CategoryId { get; set; }

    }
}
