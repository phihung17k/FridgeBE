using FridgeBE.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FridgeBE.Infrastructure.Data.EntityConfiguration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable(nameof(Ingredient).ToLowerInvariant());

            builder.HasMany(i => i.Recipes)
                   .WithMany(r => r.Ingredients)
                   .UsingEntity<IngredientRecipe>();
        }
    }
}