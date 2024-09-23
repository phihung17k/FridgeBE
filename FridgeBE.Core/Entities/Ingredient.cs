using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class Ingredient : AuditableEntity
    {
        public Ingredient() { }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string LocalName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        // foreign
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Recipe> Recipes { get; set; } = [];
    }
}