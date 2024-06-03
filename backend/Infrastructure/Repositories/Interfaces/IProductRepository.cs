using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Responses;

namespace Infrastructure.Repositories.Interfaces;

public interface IProductRepository
{
    Task<PaginatedList<GetProductResponse>> GetPaginatedAsync(int pageIndex, int pageSize);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product newProduct, List<Category> categories);
    Task<Product?> UpdateAsync(int id, Product updatedProductRequest, List<Category>? newCategories);
    Task DeleteAsync(Product productToDelete);
}