using FridgeBE.Core.Utils;
using System.ComponentModel.DataAnnotations;

namespace FridgeBE.Core.Entities
{
    public class Recipe : AuditableEntity
    {
        [Required]
        public string Id { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public List<Phase> Phases { get; set; }
    }
}