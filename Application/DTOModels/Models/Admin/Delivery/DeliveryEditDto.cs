using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Delivery
{
    public class DeliveryEditDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Type { get; set; } 

        [Required]
        public decimal Price { get; set; }
    }
}
