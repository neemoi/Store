namespace Application.DTOModels.Response.User
{
    public class OrderResponseDto
    {
        public int OrderId { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<decimal> ListProductPrices { get; set; } = new List<decimal>();

        public List<string> ListProductName { get; set; } = new List<string>();

        public List<string> ListProductMemory { get; set; } = new List<string>();

        public List<string> ListProductColor { get; set; } = new List<string>();

        public string? TypePayment { get; set; }

        public string? AmountPayment { get; set; }

        public string? TypeDelivery { get; set; }

        public string? AmountDelivery { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
