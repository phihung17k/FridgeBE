using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Models;

namespace FridgeBE.Core.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<Ingredient, IngredientModel>().ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl)).ReverseMap();
            CreateMap<Recipe, RecipeModel>().ReverseMap();
            CreateMap<Step, StepModel>().ReverseMap();
        }
    }
}