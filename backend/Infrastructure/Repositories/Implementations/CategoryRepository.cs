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
    
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _db.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _db.Categories.FindAsync(id);
    }

    public async Task<List<Category>> GetCategoriesByIdsAsync(List<int> ids)
    {
        return await _db.Categories
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
    }
}