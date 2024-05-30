namespace FridgeBE.Core.Entities
{
    public class Step
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}