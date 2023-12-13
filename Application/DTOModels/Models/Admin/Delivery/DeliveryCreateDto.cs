using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Delivery
{
    public class DeliveryCreateDto
    {
        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}
