using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Product
{
    public class ProductEditDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string? Color { get; set; }

        [Required]
        public string? Memory { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

