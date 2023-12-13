using Domain.Models;

namespace WebAPIKurs;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; } 

    public string? Description { get; set; }

    public string? Color { get; set; }

    public string? Memory { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
