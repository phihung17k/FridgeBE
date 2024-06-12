using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models;

namespace FridgeBE.Infrastructure.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IngredientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IngredientModel?> GetDetailIngredient(Guid ingredientId)
        {
            Ingredient? ingredient = await _unitOfWork.IngredientRepository.GetById(ingredientId);

            return ingredient == null ? null : _mapper.Map<IngredientModel>(ingredient);
        }
    }
}