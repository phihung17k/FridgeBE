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
                string imageFolderPath = Path.Combine(Environment.CurrentDirectory, _configuration["ExternalFilePath:ImageFolder"]!);
                if (!Directory.Exists(imageFolderPath))
                {
                    Directory.CreateDirectory(imageFolderPath);
                }

                bool isValidFileType = FileUtils.ValidateFileType(request.Image);

                if (!isValidFileType)
                    return null;

                //string filteredFileName = Path.GetInvalidFileNameChars().Aggregate(request.Image.FileName, (fileName, invalidChar) => fileName.Replace(invalidChar.ToString(), string.Empty));
                string fileName = Path.GetRandomFileName();
                fileName = Path.ChangeExtension(fileName, Path.GetExtension(request.Image.FileName));
                string filePath = Path.Combine(imageFolderPath, fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    await request.Image.CopyToAsync(fileStream);

                    return new IngredientModel
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Image = Path.GetFullPath(filePath)
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