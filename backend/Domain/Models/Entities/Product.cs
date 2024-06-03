using System.Text.Json.Serialization;

namespace Domain.Models.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<Category> Categories { get; set; } = [];
    [JsonIgnore]
    public List<CategoryProduct> CategoriesProducts { get; } = [];
}