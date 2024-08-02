using FridgeBE.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FridgeBE.Core.Models.RequestModels
{
    public class IngredientCreationRequest
    {
        [StringLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public IFormFile? Image { get; set; }

        public CategoryEnum Category { get; set; }
    }
}