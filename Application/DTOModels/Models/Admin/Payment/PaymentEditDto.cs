using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Payment
{
    public class PaymentEditDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Emount { get; set; }
    }
}
