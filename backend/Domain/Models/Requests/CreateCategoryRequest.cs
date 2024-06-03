using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests;

public class CreateCategoryRequest
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;
}