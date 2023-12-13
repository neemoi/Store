namespace WebAPIKurs;

public partial class Payment
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public decimal Amount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
