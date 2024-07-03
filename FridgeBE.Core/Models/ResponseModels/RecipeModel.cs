namespace FridgeBE.Core.Models.ResponseModels
{
    public class RecipeModel
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public List<StepModel> Steps { get; set; } = [];

        public List<IngredientModel> Ingredients { get; set; } = [];
    }
}