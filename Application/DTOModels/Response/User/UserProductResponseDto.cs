namespace Application.DTOModels.Response.User
{
    public class UserProductResponseDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public string? Color { get; set; }

        public string? Memory { get; set; }

        public string? CategoryName { get; set; }
    }
}
