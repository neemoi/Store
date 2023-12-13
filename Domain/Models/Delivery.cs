namespace WebAPIKurs;

public partial class Delivery
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
