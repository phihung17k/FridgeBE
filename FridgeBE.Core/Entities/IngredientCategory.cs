namespace FridgeBE.Core.Entities
{
    public class IngredientCategory
    {
        public int Id { get; set; }

        public Guid IngredientId { get; set; }

        public int CategoryId { get; set; }
    }
}