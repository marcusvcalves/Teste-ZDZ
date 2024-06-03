using Domain.Exceptions;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Models.Requests;
using Domain.Models.Responses;
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

    public async Task<PaginatedList<GetProductResponse>> GetPaginatedProductsAsync(int pageIndex, int pageSize)
    {
        var products = await _productRepository.GetPaginatedAsync(pageIndex, pageSize);
        return products;
    }

    public async Task<GetProductResponse> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product != null)
        {
            return _mapper.Map<GetProductResponse>(product);
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