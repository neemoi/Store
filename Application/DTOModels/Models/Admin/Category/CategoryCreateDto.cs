using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Category
{
    public class CategoryCreateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
