using Domain.Models.Entities;

namespace Domain.Models.Responses;

public class GetProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<Category> Categories { get; set; } = [];
}