using System.Net;

namespace FridgeBE.Core.Models.ResponseModels
{
    public class IngredientModel : ResponseModelBase
    {
        public IngredientModel()
        { }

        public IngredientModel(HttpStatusCode statusCode, string errorMessage) : base(statusCode, errorMessage)
        { }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string LocalName { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<RecipeModel> Recipes { get; set; } = [];
    }
}