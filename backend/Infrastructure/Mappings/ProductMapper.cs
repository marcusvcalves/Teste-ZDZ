using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Requests;

namespace Infrastructure.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<Product, UpdateProductRequest>().ReverseMap();
    }
}