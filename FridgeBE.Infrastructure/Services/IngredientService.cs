using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Exceptions;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using FridgeBE.Infrastructure.Utils;
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

        public async Task<IngredientModel?> GetDetailIngredient(Guid id)
        {
            Ingredient? ingredient = await Repository.GetById(id);

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
            await _unitOfWork.SaveChangeAsync();
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