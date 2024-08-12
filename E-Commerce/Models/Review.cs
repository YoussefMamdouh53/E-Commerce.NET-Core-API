using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Body { get; set; } = string.Empty;
        [Required]
        [Range(1,5)]
        public int Stars { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        [Required]
        public User? User { get; set; }
        [Required]
        public Product? Product { get; set; }



    }
}
