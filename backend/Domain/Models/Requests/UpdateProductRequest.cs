﻿namespace Domain.Models.Requests;

public class UpdateProductRequest
{
    public string? Name { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public List<int>? CategoriesIds { get; set; }
}