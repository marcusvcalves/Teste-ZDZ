using Domain.Models.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<List<Category>> GetCategoriesByIdsAsync(List<int> ids);
    Task<Category> CreateAsync(Category newCategory);
    Task<Category?> UpdateAsync(int id, Category updatedCategory);
    Task DeleteAsync(Category categoryToDelete);
}