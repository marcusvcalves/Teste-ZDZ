using Domain.Models.Entities;
using Domain.Models.Requests;

namespace ApplicationCore.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category> CreateCategoryAsync(CreateCategoryRequest createCategoryRequest);
    Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryRequest updateCategoryRequest);
    Task<bool> DeleteCategoryAsync(int id);
}