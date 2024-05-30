using FridgeBE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeBE.Infrastructure.Data.EntityConfiguration
{
    public class IngredientRecipeConfiguration : IEntityTypeConfiguration<IngredientRecipe>
    {
        public void Configure(EntityTypeBuilder<IngredientRecipe> builder)
        {
            builder.ToTable(nameof(IngredientRecipe).ToLowerInvariant());
        }
    }
}