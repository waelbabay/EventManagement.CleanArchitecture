namespace EventManagement.CleanArchitecture.Application.Features.Categories.Commands.CreateCategory
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
