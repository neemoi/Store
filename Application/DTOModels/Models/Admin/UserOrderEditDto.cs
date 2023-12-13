using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin
{
    public class UserOrderEditDto
    {
        [Required]
        public string? UserId { get; set; }  

        [Required]
        public int OrderId { get; set; }

        [Required]
        public List<int>? ListProductId { get; set; }

        [Required]
        public int PaymentId { get; set; }

        [Required]
        public int DeliverId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
