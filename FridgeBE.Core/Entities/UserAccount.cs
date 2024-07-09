using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class UserAccount : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public UserLogin UserLogin { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}