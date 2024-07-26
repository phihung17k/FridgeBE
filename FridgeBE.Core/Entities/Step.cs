namespace FridgeBE.Core.Entities
{
    public class Step
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string StepOrder { get; set; }

        public string? ImageUrl { get; set; }

        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}