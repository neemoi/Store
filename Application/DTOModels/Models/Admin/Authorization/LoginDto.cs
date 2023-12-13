using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Authorization
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
