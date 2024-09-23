using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.ResponseModels;

namespace FridgeBE.Core.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<Ingredient, IngredientModel>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl))
                .ReverseMap();
            CreateMap<Recipe, RecipeModel>().ReverseMap();
            CreateMap<Step, StepModel>().ReverseMap();

            CreateMap<UserAccount, RegisterResponseModel>()
                .ForMember(uam => uam.Email, opt => opt.MapFrom(ua => ua.UserLogin.Email))
                .ReverseMap();

            CreateMap<UserAccount, LoginResponseModel>()
                .ForMember(uam => uam.Email, opt => opt.MapFrom(ua => ua.UserLogin.Email))
                .ForMember(uam => uam.RefreshToken, opt => opt.MapFrom(ua => ua.UserLogin.RefreshToken))
                .ForMember(uam => uam.RefreshTokenExpireTime, opt => opt.MapFrom(ua => ua.UserLogin.RefreshTokenExpireTime))
                .ReverseMap();

            CreateMap<Pagination<Ingredient>, Pagination<IngredientModel>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ReverseMap();
        }
    }
}