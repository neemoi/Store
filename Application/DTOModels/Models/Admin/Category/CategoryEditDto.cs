using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Category
{
    public class CategoryEditDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
