using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models.ResponseModels;

namespace FridgeBE.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            Repository = (_unitOfWork.Repository<Category>() as ICategoryRepository)!;
        }

        public ICategoryRepository Repository { get; set; }

        public async Task<IReadOnlyList<CategoryResponseModel>> GetAll()
        {
            IReadOnlyList<Category> categories = await Repository.GetReadOnlyListAsync();
            return _mapper.Map<IReadOnlyList<CategoryResponseModel>>(categories);
        }
    }
}