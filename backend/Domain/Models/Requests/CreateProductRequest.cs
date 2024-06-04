using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests;

public class CreateProductRequest
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Price is required.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;
    public List<int> CategoriesIds { get; set; } = new List<int>();
}