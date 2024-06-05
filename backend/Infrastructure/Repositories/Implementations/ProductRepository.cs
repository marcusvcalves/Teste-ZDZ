using Domain.Models;
using Domain.Models.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<PaginatedList<Product>> GetPaginatedAsync(int pageIndex, int pageSize, string search = "")
    {
        var query = _db.Products.Include(p => p.Categories).AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(search.ToLower()));
        }

        var totalProducts = await query.CountAsync();
        var products = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Product>(products, pageIndex, (int)Math.Ceiling(totalProducts / (double)pageSize));
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _db.Products
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == id); 
    }

    public async Task<Product> CreateAsync(Product newProduct, List<Category> categories)
    {
        newProduct.Categories = categories;
        var addedProduct = await _db.Products.AddAsync(newProduct);
        await _db.SaveChangesAsync();
        return addedProduct.Entity;
    }

    public async Task<Product?> UpdateAsync(int id, Product updatedProduct, List<Category>? newCategories)
    {
        var existingProduct = await GetByIdAsync(id);

        if (existingProduct != null)
        {
            _db.Products.Attach(existingProduct); 

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Description = updatedProduct.Description;

            if (newCategories != null)
            {
                existingProduct.Categories.Clear();
                existingProduct.Categories.AddRange(newCategories);
            }

            await _db.SaveChangesAsync().ConfigureAwait(false);
            return existingProduct;
        }

        return null;
    }

    public async Task DeleteAsync(Product productToDelete)
    {
        _db.Products.Remove(productToDelete);
        await _db.SaveChangesAsync();
    }
}