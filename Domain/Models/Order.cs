namespace WebAPIKurs;

public partial class Order
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;
    
    public string? UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public int PaymentId { get; set; }
    
    public int DeliverId { get; set; }

    public virtual Delivery Deliveries { get; set; } = null!;

    public virtual Payment Payments { get; set; } = null!;

    public virtual CustomUser User { get; set; } = null!;

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public Order()
    {
        CreatedAt = DateTime.Now;
        Status = "new";
        TotalPrice = 0;
    }
}
