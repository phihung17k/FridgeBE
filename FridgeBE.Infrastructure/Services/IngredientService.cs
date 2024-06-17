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
        }

        public async Task<IngredientModel?> CreateIngredient(IngredientCreationRequest request)
        {
            if (request.Image != null)
            {
                string imageFolder = _configuration["AppSettings:ImagesFolder"];
                string imageFolderPath = Path.Combine(Environment.CurrentDirectory, imageFolder);
                if (!Directory.Exists(imageFolderPath))
                {
                    Directory.CreateDirectory(imageFolderPath);
                }

                int dotIndex = request.Image.FileName.LastIndexOf(".");
                string extension = request.Image.FileName.Substring(dotIndex);
                bool isSupportedFile = FileUtils.ImageExtensions.Contains(extension);

                if (!isSupportedFile)
                    return null;

                string filePath = Path.Combine(imageFolderPath, request.Image.FileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    await request.Image.CopyToAsync(fileStream);

                    return new IngredientModel
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Image = Path.GetFullPath(request.Image.FileName)
                    };
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