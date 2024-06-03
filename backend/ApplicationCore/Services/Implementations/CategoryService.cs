using Domain.Exceptions;
using ApplicationCore.Services.Interfaces;
using Domain.Models.Entities;
using Infrastructure.Repositories.Interfaces;

namespace ApplicationCore.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllCategoriesAsync();
    }
    
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category != null)
        {
            return category;
        }

        throw new NotFoundException("Category could not be found.");
    }
}