using WebAPIKurs;

namespace Application.DTOModels.Response.Admin.Authorization
{
    public class LoginResponseDto
    {
        public string? Id { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? UserRole { get; set; }

        public string? Token { get; set; }

        public string? Message { get; set; }
    }
}
