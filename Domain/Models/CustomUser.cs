using Microsoft.AspNetCore.Identity;

namespace WebAPIKurs;

public partial class CustomUser : IdentityUser
{
    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Address { get; set; }
    
    public string? City { get; set; }
    
    public string? State { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
