namespace FridgeBE.Core.Entities
{
    public class UserPermission
    {
        public int Id { get; set; }

        public Guid UserAccountId { get; set; }

        public int PermissionId { get; set; }
    }
}