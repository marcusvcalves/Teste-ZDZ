using ApplicationCore.Services.Interfaces;
using Domain.Models.Entities;
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
    
    /// <summary>
    /// Busca as categorias
    /// </summary>
    /// <response code="200">Lista com as categorias</response>
    [ProducesResponseType(typeof(List<Category>), 200)]
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    /// <summary>
    /// Busca categoria por ID
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Retorna a categoria</response>
    /// <response code="404">Categoria não encontrada</response>
    [ProducesResponseType(typeof(Category), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(category);
    }

    /// <summary>
    /// Cria uma nova categoria
    /// </summary>
    /// <param name="createCategoryRequest"></param>
    /// <response code="201">Retorna a nova categoria</response>
    /// <response code="400">Payload enviado inválido</response>
    [ProducesResponseType(typeof(Category), 201)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest createCategoryRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var newCategory = await _categoryService.CreateCategoryAsync(createCategoryRequest);
        return CreatedAtAction(nameof(CreateCategory), newCategory);
    }
    
    /// <summary>
    /// Atualiza uma categoria
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateCategoryRequest"></param>
    /// <response code="200">Retorna a categoria atualizada</response>
    /// <response code="404">Categoria não encontrada</response>
    [ProducesResponseType(typeof(Category), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequest updateCategoryRequest)
    {
        var newCategory = await _categoryService.UpdateCategoryAsync(id, updateCategoryRequest);
        return Ok(newCategory);
    }
    
    /// <summary>
    /// Exclui uma categoria
    /// </summary>
    /// <param name="id"></param>
    /// <response code="201">Categoria excluída</response>
    /// <response code="404">Categoria não encontrada</response>
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        var deleteSuccessful = await _categoryService.DeleteCategoryAsync(id);
        if (!deleteSuccessful) return NotFound();

        return NoContent();
    }
}