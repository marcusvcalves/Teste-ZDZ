using ApplicationCore.Services.Interfaces;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationCore.Controllers;

[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    /// <summary>
    /// Busca os produtos paginados
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="search"></param>
    /// <response code="200">Lista paginada com os produtos</response>
    [ProducesResponseType(typeof(PaginatedList<Product>), 200)]
    [HttpGet]
    public async Task<IActionResult> GetPaginatedProducts([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
    {
        var products = await _productService.GetPaginatedProductsAsync(pageIndex, pageSize, search);
        return Ok(products);
    }

    /// <summary>
    /// Busca produto por ID
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Retorna o produto</response>
    /// <response code="404">Produto não encontrado</response>
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    /// <param name="createProductRequest"></param>
    /// <response code="201">Retorna o novo produto</response>
    /// <response code="400">Payload enviado inválido</response>
    [ProducesResponseType(typeof(Product), 201)]
    [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProductRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var newProduct = await _productService.CreateProductAsync(createProductRequest);
        return CreatedAtAction(nameof(CreateProduct), newProduct);
    }

    /// <summary>
    /// Atualiza um produto
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateProductRequest"></param>
    /// <response code="200">Retorna o produto atualizado</response>
    /// <response code="404">Produto não encontrado</response>
    [ProducesResponseType(typeof(Product), 200)]
    [ProducesResponseType(typeof(ProblemDetails), 404)]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequest updateProductRequest)
    {
        var product = await _productService.UpdateProductAsync(id, updateProductRequest);
        return Ok(product);
    }

    /// <summary>
    /// Exclui um produto
    /// </summary>
    /// <param name="id"></param>
    /// <response code="201">Produto excluído</response>
    /// <response code="404">Produto não encontrado</response>
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        var deleteSuccessful = await _productService.DeleteProductAsync(id);
        if(!deleteSuccessful) return NotFound();

        return NoContent();
    }
}