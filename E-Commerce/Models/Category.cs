using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;

        [JsonIgnore, DefaultValue(null)]
        public int? SubCategoryId { get; set; }

        [JsonIgnore]
        public List<Category>? SubCategories { get; set; }
        [JsonIgnore]
        public Category? category { get; set; }
    }
}
