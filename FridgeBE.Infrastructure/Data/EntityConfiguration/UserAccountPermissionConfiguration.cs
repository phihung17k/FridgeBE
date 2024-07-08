using FridgeBE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeBE.Infrastructure.Data.EntityConfiguration
{
    public class UserAccountPermissionConfiguration : IEntityTypeConfiguration<UserAccountPermission>
    {
        public void Configure(EntityTypeBuilder<UserAccountPermission> builder)
        {
            builder.ToTable(nameof(UserAccountPermission).ToLowerInvariant());
        }
    }
}