namespace Domain.Models.Requests;

public class UpdateProductRequest
{
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public List<int>? CategoriesIds { get; set; }
}