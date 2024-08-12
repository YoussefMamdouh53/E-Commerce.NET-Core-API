using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.DTOs.ReviewDTO
{
    public class CreateReviewRequest
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;
        [Required]
        [Range(1, 5)]
        public int Stars { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
