namespace FridgeBE.Core.Entities.Common
{
    public class AuditableEntity : EntityBase
    {
        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset? UpdateTime { get; set; }

        public DateTimeOffset? DeleteTime { get; set; }

        public string CreateBy { get; set; }

        public string? UpdateBy { get; set; }

        public string? DeleteBy { get; set; }
    }
}