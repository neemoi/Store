namespace Application.DTOModels.Response.User
{
    public class EditProfileResposneDto
    {
        public string Email { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }
    }
}