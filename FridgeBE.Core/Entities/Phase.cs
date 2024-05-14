using System.ComponentModel.DataAnnotations;

namespace FridgeBE.Core.Entities
{
    public class Phase
    {
        [Required]
        public string Id { get; set; }

        public string Content { get; set; }

        public Recipe Recipe { get; set; }
    }
}