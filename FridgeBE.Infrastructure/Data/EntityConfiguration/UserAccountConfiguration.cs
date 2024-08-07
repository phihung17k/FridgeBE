﻿using FridgeBE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeBE.Infrastructure.Data.EntityConfiguration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable(nameof(UserAccount).ToLowerInvariant());

            builder.HasOne(ua => ua.UserLogin)
                   .WithOne(ul => ul.UserAccount)
                   .HasForeignKey<UserLogin>(ul => ul.UserAccountId)
                   .IsRequired(false);

            builder.HasMany(ua => ua.Permissions)
                   .WithMany(p => p.UserAccounts)
                   .UsingEntity<UserAccountPermission>();

            builder.HasMany(ua => ua.Recipes)
                   .WithOne(r => r.UserAccount)
                   .HasForeignKey(r => r.UserAccountId)
                   .IsRequired(false);
        }
    }
}