using FridgeBE.Core.Models;

namespace FridgeBE.Core.Interfaces.IServices
{
    public interface IIngredientService
    {
        Task<IngredientModel?> GetDetailIngredient(Guid ingredientId);
    }
}