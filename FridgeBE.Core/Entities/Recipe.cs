using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class Recipe : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTimeOffset? CookingTime { get; set; }

        public int? ServingSize { get; set; }

        public string? ImageUrl { get; set; }

        // foreign
        public Guid UserAccountId { get; set; } // author

        public UserAccount UserAccount { get; set; } 

        public List<Step> Steps { get; set; } = [];

        public List<Ingredient> Ingredients { get; set; } = [];
    }
}