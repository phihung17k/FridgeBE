using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Enums;

namespace FridgeBE.Core.Entities
{
    public partial class Category : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalName { get; set; }
        public string? Description {  get; set; }

        // foreign
        public List<Ingredient> Ingredients { get; set; }
    }
}