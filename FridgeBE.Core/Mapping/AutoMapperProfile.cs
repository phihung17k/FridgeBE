using AutoMapper;
using FridgeBE.Core.Entities;
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

            CreateMap<UserAccount, UserAccountModel>()
                .ForMember(uam => uam.Email, opt =>
                {
                    //opt.AllowNull();
                    //opt.PreCondition(ua => ua.UserLogin != null);
                    opt.MapFrom(ua => ua.UserLogin.Email);
                })
                .ForMember(uam => uam.Token, opt => opt.MapFrom(ua => ua.UserLogin.Token))
                .ReverseMap();
        }
    }
}