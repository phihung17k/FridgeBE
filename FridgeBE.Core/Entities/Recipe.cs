using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class Recipe : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public List<Phase> Phases { get; set; }
    }
}