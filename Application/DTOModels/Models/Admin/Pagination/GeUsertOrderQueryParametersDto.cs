using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Pagination
{
    public class GeUsertOrderQueryParametersDto
    {
        [Required]
        public string? UserId { get; set; }

        [Range(0, 1001, ErrorMessage = "Page must be between 0 and 100.")]
        public int Page { get; set; } = 1;

        [Range(0, 1001, ErrorMessage = "PageSize must be between 0 and 100.")]
        public int PageSize { get; set; } = 1001;

        public string SortField { get; set; } = "Id";

        public string SortOrder { get; set; } = "asc";

        public string? CreateAt { get; set; }

        public string? Status { get; set; }

        public string? Price { get; set; }

        public string? Color { get; set; }

        public string? Memory { get; set; }

        public string? TotalPrice { get; set; }

        public string? DeliveryId { get; set; }

        public string? PaymentId { get; set; }
    }
}
