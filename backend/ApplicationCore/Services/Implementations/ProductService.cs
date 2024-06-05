using Domain.Exceptions;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Requests;
using Infrastructure.Repositories.Interfaces;

namespace ApplicationCore.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<Product>> GetPaginatedProductsAsync(int pageIndex, int pageSize, string search)
    {
        var products = await _productRepository.GetPaginatedAsync(pageIndex, pageSize, search);
        return products;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product != null)
        {
            return product;
        }

        throw new NotFoundException("Product not found.");
    }

    public async Task<Product> CreateProductAsync(CreateProductRequest createProductRequest)
    {
        List<Category> categories = await _categoryRepository.GetCategoriesByIdsAsync(createProductRequest.CategoriesIds);
        var product = _mapper.Map<Product>(createProductRequest);
        return await _productRepository.CreateAsync(product, categories);
    }

    public async Task<Product> UpdateProductAsync(int id, UpdateProductRequest updateProductRequest)
    {
        List<Category>? categories = null;
        if (updateProductRequest.CategoriesIds != null)
        {
            categories = await _categoryRepository.GetCategoriesByIdsAsync(updateProductRequest.CategoriesIds);
        }

        var productToUpdate = _mapper.Map<Product>(updateProductRequest);
        
        var updatedProduct = await _productRepository.UpdateAsync(id, productToUpdate, categories);
        if (updatedProduct != null)
        {
            return updatedProduct;
        }

        throw new NotFoundException("Product not found.");
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var productToDelete =  await _productRepository.GetByIdAsync(id);
        if (productToDelete != null)
        {
            await _productRepository.DeleteAsync(productToDelete);
            return true;
        }

        throw new NotFoundException("Product not found.");
    }
}