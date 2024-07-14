using FridgeBE.Core.Entities.Common;

namespace FridgeBE.Core.Entities
{
    public class UserLogin : EntityBase
    {
        public int Id { get; set; }

        //public string LoginName { get; set; }

        /// <summary>
        /// use email to login
        /// </summary>
        public string Email { get; set; }

        public string PasswordHash { get; set; } = null!;

        /// <summary>
        /// A salt is a random string generated when a password is set
        /// It must be stored in the authentication data table along with the password hash
        /// As a random factor but fixed for each user, it intervenes in the hashing function 
        ///     so that the password hash is unique even if a user chooses the same password as another user.
        /// </summary>
        public string PasswordSalt { get; set; } = null!;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpireTime { get; set; }

        public Guid UserAccountId { get; set; }

        /// <summary>
        /// null! mean non-nullable
        /// </summary>
        public UserAccount UserAccount { get; set; } = null!;
    }
}