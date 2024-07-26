using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class Category : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description {  get; set; }

        // foreign
        public List<Ingredient> Ingredients { get; set; }
    }
}