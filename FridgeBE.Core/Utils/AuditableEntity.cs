using System.ComponentModel.DataAnnotations;

namespace FridgeBE.Core.Utils
{
    public class AuditableEntity
    {
        [Required]
        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset UpdateTime { get; set; }

        public DateTimeOffset DeleteTime { get; set; }

        [Required]
        public string CreateBy { get; set; }

        public string UpdateBy { get; set; }

        public string DeleteBy { get; set; }
    }
}