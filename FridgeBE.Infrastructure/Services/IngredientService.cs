using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Infrastructure.Repositories;
using FridgeBE.Infrastructure.Utils;
using Microsoft.Extensions.Configuration;

namespace FridgeBE.Infrastructure.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public IngredientService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            Repository = (_unitOfWork.Repository<Ingredient>() as IngredientRepository)!;
        }

        public IIngredientRepository Repository { get; set; }

        public async Task<IngredientModel?> CreateIngredient(IngredientCreationRequest request)
        {
            string filePath = await FileUtils.UploadFile(request.Image, _configuration["ExternalFilePath:ImageFolder"]);

            var ingredient = new Ingredient
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = filePath
            };

            await Repository.CreateAsync(ingredient);
            return _mapper.Map<IngredientModel>(ingredient);
        }

        public async Task<IReadOnlyList<IngredientModel>> GetAll()
        {
            IReadOnlyList<Ingredient> ingredients = await Repository.GetReadOnlyListAsync();
            return _mapper.Map<IReadOnlyList<IngredientModel>>(ingredients);
        }

        public async Task<IngredientModel?> GetDetailIngredient(Guid ingredientId)
        {
            Ingredient? ingredient = await Repository.GetById(ingredientId);

            return _mapper.Map<IngredientModel>(ingredient);
        }
    }
}