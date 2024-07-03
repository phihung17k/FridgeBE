namespace FridgeBE.Core.Models.ResponseModels
{
    public class IngredientModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public List<RecipeModel> Recipes { get; set; } = [];
    }
}