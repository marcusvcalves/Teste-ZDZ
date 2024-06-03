using ApplicationCore.Services.Interfaces;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCore.Controllers;

[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest createCategoryRequest)
    {
        var newCategory = await _categoryService.CreateCategoryAsync(createCategoryRequest);
        return CreatedAtAction(nameof(CreateCategory), newCategory);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequest updateCategoryRequest)
    {
        var newCategory = await _categoryService.UpdateCategoryAsync(id, updateCategoryRequest);
        return Ok(newCategory);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var deleteSuccessful = await _categoryService.DeleteCategoryAsync(id);
        if (!deleteSuccessful) return NotFound();

        return NoContent();
    }
}