using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Infrastructure.Repositories;
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
        }

        public async Task<IngredientModel?> CreateIngredient(IngredientCreationRequest ingredientRequest)
        {
            if (ingredientRequest.Image != null)
            {
                string imageFolder = _configuration["AppSettings:ImagesFolder"];
                string imageFolderPath = Path.Combine(Environment.CurrentDirectory, imageFolder);
                if (!Directory.Exists(imageFolderPath))
                {
                    Directory.CreateDirectory(imageFolderPath);
                }


            }

            return null;
        }

        public async Task<IngredientModel?> GetDetailIngredient(Guid ingredientId)
        {
            IngredientRepository? repo = _unitOfWork.Repository<Ingredient>() as IngredientRepository;
            Ingredient? ingredient = await repo!.GetById(ingredientId);

            return _mapper.Map<IngredientModel>(ingredient);
        }
    }
}