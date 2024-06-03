using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Requests;
using Domain.Models.Responses;

namespace ApplicationCore.Services.Interfaces;

public interface IProductService
{
    Task<PaginatedList<GetProductResponse>> GetPaginatedProductsAsync(int pageIndex, int pageSize);
    Task<GetProductResponse> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(CreateProductRequest createProductRequest);
    Task<Product> UpdateProductAsync(int id, UpdateProductRequest updateProductRequest);
    Task<bool> DeleteProductAsync(int id);
}