using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Requests;

namespace ApplicationCore.Services.Interfaces;

public interface IProductService
{
    Task<PaginatedList<Product>> GetPaginatedProductsAsync(int pageIndex, int pageSize);
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(CreateProductRequest createProductRequest);
    Task<Product> UpdateProductAsync(int id, UpdateProductRequest updateProductRequest);
    Task<bool> DeleteProductAsync(int id);
}