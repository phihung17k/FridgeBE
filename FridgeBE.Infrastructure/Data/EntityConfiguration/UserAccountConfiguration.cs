using FridgeBE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeBE.Infrastructure.Data.EntityConfiguration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable(nameof(UserAccount).ToLowerInvariant());

            builder.HasOne(uc => uc.UserLogin)
                   .WithOne(ul => ul.UserAccount)
                   .HasForeignKey<UserLogin>(ul => ul.UserAccountId)
                   .IsRequired(false);
        }
    }
}