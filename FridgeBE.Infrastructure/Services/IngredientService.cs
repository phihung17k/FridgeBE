using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Exceptions;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using FridgeBE.Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace FridgeBE.Infrastructure.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public IIngredientRepository Repository { get; set; }

        public IngredientService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            Repository = (_unitOfWork.Repository<Ingredient>() as IIngredientRepository)!;
        }

        public async Task<IngredientModel?> CreateIngredient(IngredientCreationRequest request)
        {
            string filePath = await FileUtils.UploadFile(request.Image, _configuration["ExternalFilePath:ImageFolder"]!);

            var ingredient = new Ingredient
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = filePath
            };

            await Repository.CreateAndSaveAsync(ingredient);
            return _mapper.Map<IngredientModel>(ingredient);
        }

        public async Task<IReadOnlyList<IngredientModel>> GetAll()
        {
            IReadOnlyList<Ingredient> ingredients = await Repository.GetReadOnlyListAsync();
            return _mapper.Map<IReadOnlyList<IngredientModel>>(ingredients);
        }

        public async Task<Pagination<IngredientModel>> GetPagingIngredientList(int pageIndex = 1, int pageSize = 10)
        {
            Pagination<Ingredient> ingredients = await Repository.GetPaginationAsync(orderBy: ingredients => ingredients.OrderBy(i => i.CategoryId).ThenBy(i => i.Name),                                                                            pageIndex: pageIndex, 
                                                                                     pageSize: pageSize,
                                                                                     includes: ingredients => ingredients.Category);
            return _mapper.Map<Pagination<IngredientModel>>(ingredients);
        }

        public async Task<IngredientModel?> GetDetailIngredient(Guid id)
        {
            Ingredient? ingredient = await Repository.GetById(i => i.Id == id, includes: i => i.Category);

            if (ingredient == null)
                return new IngredientModel(HttpStatusCode.NotFound, ErrorMessages.IngredientNotFound);

            return _mapper.Map<IngredientModel>(ingredient);
        }

        public async Task<IngredientModel> UpdateIngredient(Guid id, IngredientUpdateRequest ingredientRequest)
        {
            Ingredient? ingredient = await Repository.GetById(id);

            if (ingredient == null)
                return new IngredientModel(HttpStatusCode.NotFound, ErrorMessages.IngredientNotFound);

            ingredient!.Name = ingredientRequest.Name ?? ingredient.Name;
            ingredient.Description = ingredientRequest.Description ?? ingredient.Description;
            if (ingredientRequest.Image != null)
            {
                string filePath = await FileUtils.UploadFile(ingredientRequest.Image, _configuration["ExternalFilePath:ImageFolder"]!);
                ingredient.ImageUrl = filePath;
            }
            await Repository.UpdateAndSaveAsync(ingredient);
            return _mapper.Map<IngredientModel>(ingredient);
        }

        public async Task<IngredientModel> DeleteIngredient(Guid id)
        {
            Ingredient? ingredient = await Repository.GetById(id);

            if (ingredient == null)
                return new IngredientModel(HttpStatusCode.NotFound, ErrorMessages.IngredientNotFound);

            await Repository.DeleteAndSaveAsync(ingredient);
            return _mapper.Map<IngredientModel>(ingredient);
        }
    }
}