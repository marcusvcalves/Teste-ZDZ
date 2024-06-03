using System.Text.Json.Serialization;

namespace Domain.Models.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public List<Product> Products { get; set; } = [];
    [JsonIgnore]
    public List<CategoryProduct> CategoriesProducts { get; } = [];
}