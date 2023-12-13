using System.ComponentModel.DataAnnotations;

namespace Application.DTOModels.Models.Admin.Roles
{
    public class EditUserRoleDto
    {
        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? RoleId { get; set; }
    }
}
