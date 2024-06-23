using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;

namespace FridgeBE.Core.Interfaces.IServices
{
    public interface IIngredientService
    {
        IIngredientRepository Repository { get; set; }
        Task<IngredientModel?> CreateIngredient(IngredientCreationRequest ingredientRequest);
        Task<IngredientModel?> GetDetailIngredient(Guid ingredientId);
        Task<IReadOnlyList<IngredientModel>> GetAll();
    }
}