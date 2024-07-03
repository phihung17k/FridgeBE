namespace FridgeBE.Core.Models.ResponseModels
{
    public class StepModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public Guid RecipeId { get; set; }
        public RecipeModel Recipe { get; set; }
    }
}