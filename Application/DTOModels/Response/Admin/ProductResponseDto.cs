namespace Application.DTOModels.Response.Admin
{
    public class ProductResponseDto
    {
        public int Id { get; set; }

        public string? Name { get; set; } 

        public string? Description { get; set; } 

        public double Price { get; set; }

        public string? Color { get; set; }

        public string? Memory { get; set; }

        public int CategoryId { get; set; }
    }
}
