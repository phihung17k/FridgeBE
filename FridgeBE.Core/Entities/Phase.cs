namespace FridgeBE.Core.Entities
{
    public class Phase
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public Recipe Recipe { get; set; }
    }
}