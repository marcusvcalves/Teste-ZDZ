using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Requests;
using Domain.Models.Responses;

namespace Infrastructure.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, GetProductResponse>().ReverseMap();
        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<Product, UpdateProductRequest>().ReverseMap();
    }
}