namespace Application.DTOModels.Response.Admin
{
    public class DeliveryResponseDto
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
