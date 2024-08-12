using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs.CategoryDTO
{
    public record CategoryDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public int? SubCategoryId { get; set; } = null;

    }
}
