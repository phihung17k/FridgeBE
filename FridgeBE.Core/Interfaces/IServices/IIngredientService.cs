using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;

namespace FridgeBE.Core.Interfaces.IServices
{
    public interface IIngredientService
    {
        Task<IngredientModel?> CreateIngredient(IngredientCreationRequest ingredientRequest);
        Task<IngredientModel?> GetDetailIngredient(Guid ingredientId);
    }
}