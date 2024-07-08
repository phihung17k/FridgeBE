namespace FridgeBE.Core.Entities
{
    public class Permission
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public List<UserAccount> UserAccounts { get; set; }
    }
}