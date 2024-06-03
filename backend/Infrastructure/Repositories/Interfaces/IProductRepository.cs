using Domain.Models;
using Domain.Models.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IProductRepository
{
    Task<PaginatedList<Product>> GetPaginatedAsync(int pageIndex, int pageSize);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product newProduct, List<Category> categories);
    Task<Product?> UpdateAsync(int id, Product updatedProduct, List<Category>? newCategories);
    Task DeleteAsync(Product productToDelete);
}