using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Payment
{
    public class PaymentCreateDto
    {
        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }
    }
}
