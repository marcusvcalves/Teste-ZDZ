using Domain.Exceptions;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Requests;
using Infrastructure.Repositories.Interfaces;

namespace ApplicationCore.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }
    
    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category != null)
        {
            return category;
        }

        throw new NotFoundException("Category could not be found.");
    }

    public async Task<Category> CreateCategoryAsync(CreateCategoryRequest createCategoryRequest)
    {
        var category = _mapper.Map<Category>(createCategoryRequest);
        return await _categoryRepository.CreateAsync(category);
    }

    public async Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryRequest updateCategoryRequest)
    {
        var categoryToUpdate = _mapper.Map<Category>(updateCategoryRequest);
        
        var updatedCategory = await _categoryRepository.UpdateAsync(id, categoryToUpdate);
        if (updatedCategory != null)
        {
            return updatedCategory;
        }

        throw new NotFoundException("Category not found.");
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var categoryToDelete = await _categoryRepository.GetByIdAsync(id);
        if (categoryToDelete != null)
        {
            await _categoryRepository.DeleteAsync(categoryToDelete);
            return true;
        }

        throw new NotFoundException("Category not found.");
    }
}