using AutoMapper;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Responses;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GetProductResponse>> GetPaginatedAsync(int pageIndex, int pageSize)
    {
        var totalProducts = await _db.Products.CountAsync();
        var products = await _db.Products
            .Include(p => p.Categories)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var productDtos = _mapper.Map<List<GetProductResponse>>(products); 

        return new PaginatedList<GetProductResponse>(productDtos, pageIndex, (int)Math.Ceiling(totalProducts / (double)pageSize));
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

    public async Task<Product?> UpdateAsync(int id, Product updatedProductRequest, List<Category>? newCategories)
    {
        var existingProduct = await GetByIdAsync(id);

        if (existingProduct != null)
        {
            _db.Products.Attach(existingProduct); 

            existingProduct.Name = updatedProductRequest.Name;
            existingProduct.Price = updatedProductRequest.Price;

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