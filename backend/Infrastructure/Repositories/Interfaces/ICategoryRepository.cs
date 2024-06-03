using Domain.Models.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<List<Category>> GetCategoriesByIdsAsync(List<int> ids);
}