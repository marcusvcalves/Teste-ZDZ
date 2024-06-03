using Domain.Models.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _db;

    public CategoryRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Category>> GetAllAsync()
    {
        return await _db.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _db.Categories.FindAsync(id);
    }

    public async Task<List<Category>> GetCategoriesByIdsAsync(List<int> ids)
    {
        return await _db.Categories
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
    }

    public async Task<Category> CreateAsync(Category newCategory)
    {
        var addedCategory = await _db.Categories.AddAsync(newCategory);
        await _db.SaveChangesAsync();
        return addedCategory.Entity;
    }

    public async Task<Category?> UpdateAsync(int id, Category updatedCategory)
    {
        var existingCategory = await GetByIdAsync(id);

        if (existingCategory != null)
        {
            _db.Categories.Attach(existingCategory);

            existingCategory.Name = updatedCategory.Name;

            await _db.SaveChangesAsync().ConfigureAwait(false);
            return existingCategory;
        }

        return null;
    }

    public async Task DeleteAsync(Category categoryToDelete)
    {
        _db.Categories.Remove(categoryToDelete);
        await _db.SaveChangesAsync();
    }
}