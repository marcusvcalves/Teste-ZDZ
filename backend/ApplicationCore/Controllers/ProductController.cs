using ApplicationCore.Services.Interfaces;
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
    
    [HttpGet]
    public async Task<IActionResult> GetPaginatedProducts([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
    {
        var products = await _productService.GetPaginatedProductsAsync(pageIndex, pageSize);
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProductRequest)
    {
        var newProduct = await _productService.CreateProductAsync(createProductRequest);
        return Ok(newProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequest updateProductRequest)
    {
        var product = await _productService.UpdateProductAsync(id, updateProductRequest);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        var deleteSuccessful = await _productService.DeleteProductAsync(id);
        if(!deleteSuccessful) return NotFound();

        return NoContent();
    }
}