namespace Application.DTOModels.Models.Admin
{
    public class ErrorDto
    {
        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public string? Description { get; set; }

        public string? Timestamp { get; set; }

        public string? StackTrace { get; set; }
    }
}
