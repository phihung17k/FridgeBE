namespace FridgeBE.Core.Models.ResponseModels
{
    public class UserAccountModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }
    }
}