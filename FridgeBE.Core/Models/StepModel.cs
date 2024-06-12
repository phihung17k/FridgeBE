namespace FridgeBE.Core.Models
{
    public class StepModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Guid RecipeId { get; set; }
        public RecipeModel Recipe { get; set; }
    }
}