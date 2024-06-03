using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Requests;

namespace Infrastructure.Mappings;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
    }
}