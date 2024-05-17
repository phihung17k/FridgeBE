namespace FridgeBE.Core.Entities
{
    public class IngredientRecipe
    {
        public int Id { get; set; }

        public Guid IngredientId { get; set; }

        public Guid RecipeId { get; set; }
    }
}