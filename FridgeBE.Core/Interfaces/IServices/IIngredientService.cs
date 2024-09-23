using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;

namespace FridgeBE.Core.Interfaces.IServices
{
    public interface IIngredientService
    {
        IIngredientRepository Repository { get; set; }
        Task<IngredientModel?> CreateIngredient(IngredientCreationRequest request);
        Task<IngredientModel?> GetDetailIngredient(Guid id);
        Task<IReadOnlyList<IngredientModel>> GetAll();
        Task<Pagination<IngredientModel>> GetPagingIngredientList(int pageIndex = 1, int pageSize = 10);
        Task<IngredientModel> UpdateIngredient(Guid id, IngredientUpdateRequest request);
        Task<IngredientModel> DeleteIngredient(Guid id);
    }
}