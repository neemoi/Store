using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Pagination
{
    public class DeliveryQueryParametersDto
    {
        [Range(0, 1001, ErrorMessage = "Page must be between 0 and 100.")]
        public int Page { get; set; } = 1;

        [Range(0, 1001, ErrorMessage = "PageSize must be between 0 and 100.")]
        public int PageSize { get; set; } = 1001;

        public string SortField { get; set; } = "Id";

        public string SortOrder { get; set; } = "asc";

        public string? Id { get; set; }

        public string? Type { get; set; }

        public string? Price { get; set; }
    }
}
