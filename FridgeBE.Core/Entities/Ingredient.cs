using FridgeBE.Core.Utils;

namespace FridgeBE.Core.Entities
{
    public class Ingredient : AuditableEntity
    {
        public required string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

    }
}