using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.User
{
    public class EditProfileDto
    {
        public string? Email { get; set; }

        [Required]
        public string CurrentPassword { get; set; } = null!;

        [Required]
        public string NewPassword { get; set; } = null!;

        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }
    }
}
