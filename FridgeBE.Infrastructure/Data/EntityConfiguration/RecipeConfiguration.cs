using FridgeBE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeBE.Infrastructure.Data.EntityConfiguration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable(nameof(Recipe).ToLowerInvariant());

            builder.HasMany(recipe => recipe.Steps)
                   .WithOne(step => step.Recipe)
                   .HasForeignKey(step => step.RecipeId)
                   .IsRequired(false);
        }
    }
}