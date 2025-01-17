using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models.ResponseModels;

namespace FridgeBE.Core.Interfaces.IServices
{
    public interface ICategoryService
    {
        ICategoryRepository Repository { get; set; }
        Task<IReadOnlyList<CategoryResponseModel>> GetAll();
    }
}