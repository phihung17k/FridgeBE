namespace FridgeBE.Core.Entities
{
    public class IngredientRecipe
    {
        public int Id { get; set; }

        public int? IngredientQuantity { get; set; }

        public string? IngredientQuantityUnit { get; set; } // unit of ingredient quantity

        public Guid IngredientId { get; set; }

        public Guid RecipeId { get; set; }
    }
}