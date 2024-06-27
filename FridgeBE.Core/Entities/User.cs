using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<string> Claims { get; set; }
    }
}